using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using terrasur;
using System.Data;

public partial class modulo_consultas_odoo_migracion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            


        }
    }
    protected void btnVer_Click(object sender, EventArgs e)
    {
        if(txtTrans.Text!="")
        {
            string trans = "," + txtTrans.Text.Trim() + ",";
            DataTable dt = new DataTable();

            if (cbDia.Checked == true)
            { 
                dt = cajaReporte.ReporteIngresos(0, 0, 0, cp_fecha.SelectedDate, cp_fecha.SelectedDate, ",3,", 2, true);
                lblTotal.Text = dt.Rows.Count.ToString();
                //lblMensaje.Text = "Nro. de transacciones: " + dt.Rows.Count.ToString();
            }
            else
            { dt = cajaReporte.ReporteIngresosTransaccion(0, 0, 0, cp_fecha.SelectedDate, cp_fecha.SelectedDate, ",3,", 2, true, trans); }
           
            lblTotal.Text = dt.Rows.Count.ToString();
            gvData.DataSource = dt;
            gvData.DataBind();

            int errores = 0;
            int validos = 0;
            lblError.Text = errores.ToString();
            lblValidos.Text = validos.ToString();
           
        }
    }
    protected void btnMigrar_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        lblFin.Text = "";
        lblInicio.Text = "";
        lblMensaje.Text = "";
        lblTotal.Text = "";
        lblTransInvalid.Text = "";
        lblValidos.Text = "";
        lblInicio.Text = DateTime.Now.ToString();
        lblMensaje.Text = "";
        string trans = "," + txtTrans.Text.Trim() + ",";
         DataTable dt =new DataTable();
        if (cbDia.Checked == true)
        {   dt= cajaReporte.ReporteIngresos(0, 0, 0, cp_fecha.SelectedDate, cp_fecha.SelectedDate, ",3,", 2, true);}
        else
        {   dt= cajaReporte.ReporteIngresosTransaccion(0, 0, 0, cp_fecha.SelectedDate, cp_fecha.SelectedDate, ",3,", 2, true, trans); }
      
        lblTotal.Text = dt.Rows.Count.ToString();
        gvData.DataSource = dt;
        gvData.DataBind();
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
                if (i < 500)
                { //////////////////datos generales/////////////////////////
                    string dato = dr["total_dpr"].ToString().Replace(",", ".");
                    fecha_hora = DateTime.Parse(dr["fecha_pago"].ToString());
                    string id_urbanizacion = "";
                    string nombre_urbanizacion = "";
                    string nombre_corto = "";
                    string numero_contrato = "";

                    //float monto_pago1 = 0;
                    //float monto_interes1 = 0;
                    //float monto_capital1 = 0;

                    //string monto_pagoS = "";
                    //string monto_interesS = "";
                    //string monto_capitalS = "";

                    decimal monto_pago = 0;
                    decimal monto_interes = 0;
                    decimal monto_capital = 0;

                 
                    decimal costo_lote = 0;
                    decimal costo_lote_bs = 0;
                    decimal porcentaje_bs = 0;
                    decimal precio_final_bs = 0;
                    decimal costo_pagado_bs = 0;

                 

                    //monto_pago1 =(float) Math.Round(decimal.Parse(dr["monto_pago"].ToString().Replace(".", ",")),2);
                    //monto_interes1 = (float)Math.Round(decimal.Parse(dr["interes"].ToString().Replace(".", ",")), 2);
                    //monto_capital1 = (float)Math.Round(decimal.Parse(dr["amortizacion"].ToString().Replace(".", ",")), 2);

                    //monto_pagoS = monto_pago1.ToString("F2");
                    //monto_interesS = monto_interes1.ToString("F2");
                    //monto_capitalS = monto_capital1.ToString("F2");
                    //monto_pago = float.Parse(monto_pago1.ToString(),System.Globalization.NumberStyles.Float, new System.Globalization.CultureInfo("es-ES"));

                    monto_pago = Math.Round(decimal.Parse(dr["monto_pago"].ToString().Replace(".", ",")), 2);
                    monto_interes = Math.Round(decimal.Parse(dr["interes"].ToString().Replace(".", ",")), 2);
                    monto_capital = Math.Round(decimal.Parse(dr["amortizacion"].ToString().Replace(".", ",")), 2);

                    decimal saldo_costo = 0;
                    decimal precio_final = 0;
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
                        nombre_urbanizacion = urb.nombre.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ").Replace(",","");
                        nombre_corto = urb.nombre_corto.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ").Replace(",", "");
                        costo_lote = Math.Round(objcv.superficie_m2 * objcv.costo_m2_sus,2);
                        costo_lote_bs = Math.Round(costo_lote * decimal.Parse(dr["tipo_cambio"].ToString()),2);
                        if (dr["codigo_moneda"].ToString().Trim() == "$us")
                        { precio_final_bs = Math.Round(objcv.precio_final * decimal.Parse(dr["tipo_cambio"].ToString()), 2); }
                        else
                        { precio_final_bs = Math.Round(objcv.precio_final,2); }
                        
                        porcentaje_bs=decimal.Parse(monto_capital.ToString())/precio_final_bs;
                        costo_pagado_bs =Math.Round( costo_lote_bs * porcentaje_bs,2);
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

                        string resultado="";
                        string resultado2="";
                        string resultado3="";
                        string resultado4 = "";

                        if (cbEfectivo.Checked == true)
                        {
                            resultado = obj.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, tipo_pago,
                             monto_pago, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                             nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, 0, true, 0, true);

                        }

                        if (cbVentaLotesEfectivo.Checked == true)
                        {
                            ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();
                            resultado2 = obj2.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, "VENTA DE LOTES EFECTIVO Y DPR",
                               0, true, 0, true, 0, true, 0, true, precio_final_bs, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                               nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, 0, true, 0, true);
                        }

                        if (cbCosto.Checked == true)
                        {

                            ServiceReference1.SintesisService obj3 = new ServiceReference1.SintesisService();
                            resultado3 = obj3.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, "INVENTARIO CAPITAL PAGADO",
                              0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                              nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, costo_pagado_bs, true, 0, true);
                        }

                        if (cbVentaLotesCosto.Checked == true)
                        {
                            ServiceReference1.SintesisService obj4 = new ServiceReference1.SintesisService();
                            resultado4 = obj4.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, "INVENTARIO VENTA DE LOTES",
                              0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                              nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), costo_lote_bs, true, 0, true, 0, true);
                        }

                        if (resultado.Contains("error"))
                        {
                            errores++;
                            lblTransInvalid.Text = lblTransInvalid.Text + "," + id_transaccion + "(" + tipo_pago + ") ";
                        }
                        else
                        {
                            if (resultado2.Contains("error"))
                            {
                                errores++;
                                lblTransInvalid.Text = lblTransInvalid.Text + "," + id_transaccion + "(" + tipo_pago + ") ";
                            }
                            else
                            {
                                if (resultado3.Contains("error"))
                                {
                                    errores++;
                                    lblTransInvalid.Text = lblTransInvalid.Text + "," + id_transaccion + "(" + tipo_pago + ") ";
                                }
                                else
                                    if (resultado4.Contains("error"))
                                {
                                    errores++;
                                    lblTransInvalid.Text = lblTransInvalid.Text + "," + id_transaccion + "(" + tipo_pago + ") ";
                                }
                                else
                                {
                                    validos++;
                                }

                            }
                        }







                    }
                    /////////////////FIN CUOTAS INICIALES///////////////////////////
                    /////////////////PAGO NORMAL///////////////////////////
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

                        if (cbEfectivo.Checked == true)
                        {
                            ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                            resultado = obj.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, tipo_pago,
                           0, true, monto_pago, true, monto_interes, true, monto_capital, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                           nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, 0, true, 0, true);
                        }


                        if (cbCosto.Checked == true)
                        {
                            ServiceReference1.SintesisService obj1 = new ServiceReference1.SintesisService();
                            resultado2 = obj1.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion.ToString(), 0, true, "INVENTARIO CAPITAL PAGADO",
                                0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion.ToString(), "", "", efectivo, true,
                                nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, costo_pagado_bs, true, 0, true);
                        }

                        if (resultado.Contains("error"))
                        {
                            errores++;
                            lblTransInvalid.Text = lblTransInvalid.Text + "," + id_transaccion + "(" + tipo_pago + ") ";
                        }
                        else
                        {
                            if (resultado2.Contains("error"))
                            {
                                errores++;
                                lblTransInvalid.Text = lblTransInvalid.Text + "," + id_transaccion + "(" + tipo_pago + ") ";
                            }
                            else
                            { validos++; }
                        }
                    }
                    ///////////////FIN PAGO NORMAL///////////////////////////
                    /////////////////PAGO ADELANTADO///////////////////////////
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

                        if (cbEfectivo.Checked == true)
                        {
                            resultado = obj.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, tipo_pago,
                           0, true, monto_pago, true, monto_interes, true, monto_capital, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                           nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, 0, true, 0, true);
                        }

                        if (cbCosto.Checked == true)
                        {
                            ServiceReference1.SintesisService obj1 = new ServiceReference1.SintesisService();
                            resultado2 = obj1.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion.ToString(), 0, true, "INVENTARIO CAPITAL PAGADO",
                                0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion.ToString(), "", "", efectivo, true,
                                nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, costo_pagado_bs, true, 0, true);
                        }
                        if (resultado.Contains("error"))
                        {
                            errores++;
                            lblTransInvalid.Text = lblTransInvalid.Text + "," + id_transaccion + "(" + tipo_pago + ") ";
                        }
                        else
                        {
                            if (resultado2.Contains("error"))
                            {
                                errores++;
                                lblTransInvalid.Text = lblTransInvalid.Text + "," + id_transaccion + "(" + tipo_pago + ") ";
                            }
                            else
                            { validos++; }
                        }
                    }
                    /////////////////FIN PAGO ADELANTADO///////////////////////////
                    /////////////////PAGO SEGUN PLAN///////////////////////////
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

                        if (cbEfectivo.Checked == true)
                        {
                            resultado = obj.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, tipo_pago,
                               0, true, monto_pago, true, monto_interes, true, monto_capital, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                               nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, 0, true, 0, true);
                        }
                        if (cbCosto.Checked == true)
                        {
                            ServiceReference1.SintesisService obj1 = new ServiceReference1.SintesisService();
                            resultado2 = obj1.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion.ToString(), 0, true, "INVENTARIO CAPITAL PAGADO",
                                0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion.ToString(), "", "", efectivo, true,
                                nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, costo_pagado_bs, true, 0, true);
                        }
                        if (resultado.Contains("error"))
                        {
                            errores++;
                            lblTransInvalid.Text = lblTransInvalid.Text + "," + id_transaccion + "(" + tipo_pago + ") ";
                        }
                        else
                        {
                            if (resultado2.Contains("error"))
                            {
                                errores++;
                                lblTransInvalid.Text = lblTransInvalid.Text + "," + id_transaccion + "(" + tipo_pago + ") ";
                            }
                            else
                            { validos++; }
                        }
                    }
                    /////////////////FIN PAGO SEGUN PLAN///////////////////////////
                    /////////////////PAGO DIRECTO A CAPITAL///////////////////////////
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

                        if (cbEfectivo.Checked == true)
                        {
                            ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                            resultado = obj.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, tipo_pago,
                               0, true, monto_pago, true, monto_interes, true, monto_capital, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion, "", "", efectivo, true,
                               nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, 0, true, 0, true);
                        }
                        if (cbCosto.Checked == true)
                        {
                            ServiceReference1.SintesisService obj1 = new ServiceReference1.SintesisService();
                            resultado2 = obj1.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion.ToString(), 0, true, "INVENTARIO CAPITAL PAGADO",
                                0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion.ToString(), "", "", efectivo, true,
                                nombre_urbanizacion, "", false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, costo_pagado_bs, true, 0, true);
                        }
                        if (resultado.Contains("error"))
                        {
                            errores++;
                            lblTransInvalid.Text = lblTransInvalid.Text + "," + id_transaccion + "(" + tipo_pago + ") ";
                        }
                        else
                        {
                            if (resultado2.Contains("error"))
                            {
                                errores++;
                                lblTransInvalid.Text = lblTransInvalid.Text + "," + id_transaccion + "(" + tipo_pago + ") ";
                            }
                            else
                            { validos++; }
                        }
                    }
                    ///////////////// FIN PAGO DIRECTO A CAPITAL///////////////////////////
                    /////////////////PAGO OTROS SERVICIOS///////////////////////////
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

                        if (cbEfectivo.Checked == true)
                        {
                            ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();
                            resultado = obj2.insertarMovimientosOdoo(3, true, numero_contrato, "", id_transaccion, 0, true, tipo_operacion, 0,
                                true, 0, true, 0, true, 0, true, 0, true, 0, true, otro_serv_facturado, true, otro_serv_sin_factura, true, id_urbanizacion, "", "", efectivo, true,
                                nombre_urbanizacion, dr["servicio_codigo"].ToString(), false, true, 1, true, ip, fecha_hora.ToShortDateString(), 0, true, 0, true, 0, true);
                        }
                        if (resultado.Contains("error"))
                        {
                            errores++;
                            lblTransInvalid.Text = lblTransInvalid.Text + "," + id_transaccion + "(" + tipo_operacion + ") ";
                        }
                        else
                        { validos++; }
                    }
                }


                i++;


            }
        }
        lblMensaje.Text = "FIN DEL PROCESO DE MIGRACION";
        lblFin.Text = DateTime.Now.ToString();
        lblError.Text = errores.ToString();
        lblValidos.Text = validos.ToString();
    }
    protected void btnVerTrans_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        lblFin.Text = "";
        lblInicio.Text = "";
        lblMensaje.Text = "";
        lblTotal.Text = "";
        lblTransInvalid.Text = "";
        lblValidos.Text = "";
        txtTrans.Text = "";
        DataTable dt = cajaReporte.ReporteIngresos(0, 0, 0, cp_fecha.SelectedDate, cp_fecha.SelectedDate, ",3,", 2, true);
        if (cbDia.Checked == true)
        {
            gvData.DataSource = dt;
            gvData.DataBind();
            lblTotal.Text = dt.Rows.Count.ToString();
        }
        else
        {
            if (dt.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    txtTrans.Text = txtTrans.Text + "," + dr["id_transaccion"];
                    i++;
                }
                lblMensaje.Text = "Nro. de transacciones: " + i.ToString();
            }
            else
            {
                lblMensaje.Text = "No existen transacciones";
            }
        }
        
        
    }
    protected void cbDia_CheckedChanged(object sender, EventArgs e)
    {
        if (cbDia.Checked == true)
        {
            txtTrans.Enabled = false;
            txtTrans.Text = "";
        }
        else
        {
            txtTrans.Enabled = true;
            txtTrans.Text = "";
        }
        
    }
    protected void btnVerRev_Click(object sender, EventArgs e)
    {
        lblMsjRev.Text = "Nro. de reversiones: 0" ;
        lblTotal.Text = "0";
        DataTable dt = new DataTable();
        dt = contratoReporte.ReporteReversion(cp_fecha_rev1.SelectedDate, cp_fecha_rev2.SelectedDate, ",3,", 2, true, DateTime.Parse("01/01/1900"), DateTime.Parse("01/01/5900"));
        if (cbRevTxt.Checked == true)
        {
            if (txtRev.Text != "")
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = "id_reversion=" + txtRev.Text.Trim();
                gvData2.DataSource = dv;
                gvData2.DataBind();
                lblMsjRev.Text = "Nro. de reversiones: " + dv.Count.ToString();
                lblTotal.Text = dv.Count.ToString();
            }
            
        }
        else
        {
            gvData2.DataSource = dt;
            gvData2.DataBind();
            lblMsjRev.Text = "Nro. de reversiones: " + dt.Rows.Count.ToString();
            lblTotal.Text = dt.Rows.Count.ToString();
        }
       
       
    }
    protected void btnMigrarRev_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        lblFin.Text = "";
        lblInicio.Text = "";
        lblMensaje.Text = "";
        lblTotal.Text = "";
        lblTransInvalid.Text = "";
        lblValidos.Text = "";
        lblInicio.Text = DateTime.Now.ToString();
        lblMsjRev.Text = "";
        DataTable dt = new DataTable();
        dt = contratoReporte.ReporteReversion(cp_fecha_rev1.SelectedDate, cp_fecha_rev2.SelectedDate, ",3,", 2, true, DateTime.Parse("01/01/1900"), DateTime.Parse("01/01/5900"));
        lblTotal.Text = dt.Rows.Count.ToString();
        string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
        int errores = 0;
        int validos = 0;
        foreach (DataRow dr in dt.Rows)
        {
            int id_contrato = int.Parse(dr["id_contrato"].ToString());
            int id_reversion = int.Parse(dr["id_reversion"].ToString());
            int id_usuario = int.Parse(dr["id_usuario"].ToString());
            int id_urbanizacion=int.Parse(dr["id_urbanizacion"].ToString());
            int id_lote = int.Parse(dr["id_lote"].ToString());
            string numero = dr["contrato_numero"].ToString();
            string usuario=dr["usuario"].ToString();
            string nombre_urbanizacion = dr["sector_nombre"].ToString().Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ");
            decimal cap_adeuda =Math.Round(decimal.Parse(dr["capital_deudor"].ToString()));
            DateTime fecha = DateTime.Parse(dr["fecha_reversion"].ToString());
            string resultado = "";
            string resultado2 = "";
            if (cbRevTxt.Checked == true)
            {
                if (id_reversion == int.Parse(txtRev.Text))
                {
                    if (cb_rev_efectivo.Checked == true)
                    {

                        ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();
                        resultado = obj2.insertarMovimientosOdoo(3, true, numero, "", id_reversion.ToString(), 0, true, "REVERSIONES",
                            0, true, 0, true, 0, true, 0, true, 0, true, cap_adeuda, true, 0, true, 0, true, id_urbanizacion.ToString(),
                            "", "", true, true, nombre_urbanizacion, "", false, true, id_usuario,
                            true, ip, fecha.ToShortDateString(), 0, true, 0, true, 0, true);
                    }

                    if (cb_rev_costo.Checked == true)
                    {
                        ////////////////INVENTARIOS////////////////
                        lote lot = new lote(id_lote);
                        contrato ob_con = new contrato(id_contrato);
                        negocio_contrato neg = new negocio_contrato(ob_con.id_negociocontrato);
                        contrato_venta ob_cv = new contrato_venta(id_contrato);
                        tipo_cambio tc = new tipo_cambio(DateTime.Now);
                        
                        decimal costo_lote = Math.Round(ob_cv.superficie_m2 * ob_cv.costo_m2_sus, 2);
                        decimal porcentaje = Math.Round(ob_cv.capital_pagado / ob_con.precio_final,2);
                        decimal costo_pagado =Math.Round(costo_lote * porcentaje,2);
                        decimal saldo_costo = Math.Round(costo_lote - costo_pagado);

                        decimal costo_lote_bs = 0;
                        decimal costo_pagado_bs = 0;
                        decimal saldo_costo_bs = 0;

                        string costo_lote_bsF = "0";
                        string costo_pagado_bsF = "0";
                        string saldo_costo_bsF = "0";

                        decimal costo_lote_bsF2 = 0;
                        decimal costo_pagado_bsF2 = 0;
                        decimal saldo_costo_bsF2 = 0;

                        costo_lote_bs = Math.Round(costo_lote * tc.compra, 2);
                        costo_pagado_bs =Math.Round(costo_pagado * tc.compra, 2);
                        saldo_costo_bs =Math.Round(saldo_costo * tc.compra, 2);

                        costo_lote_bsF = costo_lote_bs.ToString("F2");
                        costo_pagado_bsF =costo_pagado_bs.ToString("F2");
                        saldo_costo_bsF = saldo_costo_bs.ToString("F2");

                        costo_lote_bsF2 = Math.Round(costo_lote * tc.compra, 2);
                        costo_pagado_bsF2 = Math.Round(costo_pagado * tc.compra, 2);
                        saldo_costo_bsF2 = costo_lote_bsF2 - costo_pagado_bsF2; //verificarDecimal(saldo_costo_bsF);

                        //costo_lote_bsF2 = costo_pagado_bsF2+saldo_costo_bsF2;
                  

                          ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                          resultado2 = obj.insertarMovimientosOdoo(3, true, numero.ToString(), "", id_reversion.ToString(), 0, true, "INVENTARIO REVERSIONES",
                             0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, id_urbanizacion.ToString(),
                             "", "", true, true, nombre_urbanizacion, "", false, true, id_usuario,
                             true, ip, fecha.ToShortDateString(), costo_lote_bsF2, true, costo_pagado_bsF2, true, saldo_costo_bsF2, true);
                    }
                    if (resultado.Contains("error"))
                    {
                        errores++;
                        lblTransInvalid.Text = lblTransInvalid.Text + "," + id_reversion + "(EFECTIVO) ";
                    }
                    else
                    {
                        if (resultado2.Contains("error"))
                        {
                            errores++;
                            lblTransInvalid.Text = lblTransInvalid.Text + "," + id_reversion + "(COSTO) ";
                        }
                        else
                        { validos++; }
                    }
                }
            }
            else
            {
                ////////////////REVIERTE TODAS LAS REVERSIONES DE LAS FECHAS ELEGIDAS///////////////////
                if (cb_rev_efectivo.Checked == true)
                {

                    ServiceReference1.SintesisService obj2 = new ServiceReference1.SintesisService();
                    resultado = obj2.insertarMovimientosOdoo(3, true, numero, "", id_reversion.ToString(), 0, true, "REVERSIONES",
                        0, true, 0, true, 0, true, 0, true, 0, true, cap_adeuda, true, 0, true, 0, true, id_urbanizacion.ToString(),
                        "", "", true, true, nombre_urbanizacion, "", false, true, id_usuario,
                        true, ip, fecha.ToShortDateString(), 0, true, 0, true, 0, true);
                }

                if (cb_rev_costo.Checked == true)
                {
                    ////////////////INVENTARIOS////////////////
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
                if (resultado.Contains("error"))
                {
                    errores++;
                    lblTransInvalid.Text = lblTransInvalid.Text + "," + id_reversion + "(EFECTIVO) ";
                }
                else
                {
                    if (resultado2.Contains("error"))
                    {
                        errores++;
                        lblTransInvalid.Text = lblTransInvalid.Text + "," + id_reversion + "(COSTO) ";
                    }
                    else
                    { validos++; }
                }
            }
            
          
           
        }
        lblMensaje.Text = "FIN DEL PROCESO DE MIGRACION";
        lblFin.Text = DateTime.Now.ToString();
        lblError.Text = errores.ToString();
        lblValidos.Text = validos.ToString();
    }

    

    public float verificarDecimal(string numero)
    {
        float resultado = 0;
        int numEnero = int.Parse(numero.Split(',')[0]);
        decimal numDecimal = decimal.Parse("0," + numero.Split(',')[1]);
        if (numDecimal <= decimal.Parse("0,05"))
        {
            resultado = float.Parse(numEnero.ToString());
        }
        else
        {

            resultado = float.Parse(numero);
        }

        return resultado;
    }
    protected void btnTrans_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnRev_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }

    protected void btnLotes_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }

    protected void btnMigrarLotes_Click(object sender, EventArgs e)
    {

        foreach (ListItem item in cblLote.Items)
        {
            if (item.Selected == true)
            {
                
                int id_lote =int.Parse(item.Value);
                lote lot = new lote(id_lote);
                negocio_lote neg_lot = new negocio_lote(lot.id_negociolote);
                if (neg_lot.id_negocio == 3)
                {
                    tipo_cambio tc = new tipo_cambio(DateTime.Now);
                    string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                    ////////////////INVENTARIOS////////////////
                    decimal costo_lote = lot.superficie_m2 * lot.costo_m2_sus * tc.compra;
                    string nombre_urbanizacion = "";
                    nombre_urbanizacion = ddlUrbanizacion.SelectedItem.Text.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ").Replace(",", ".") + " " + ddlManzano.SelectedItem.Text.Trim() + " " + item.Text.Trim();
                    ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
                    string resultado = obj.insertarMovimientosOdoo(3, true, "0", "", id_lote.ToString(), 0, true, "INVENTARIO CREACION DE LOTES",
                        0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, ddlUrbanizacion.SelectedValue, "", "", true, true, nombre_urbanizacion, "", false, true, lot.id_usuario,
                        true, ip, DateTime.Now.ToShortDateString(), costo_lote, true, 0, true, 0, true);
                }
                
            }


        }
        //if (_id_lote > 0)
        //{
        //    if (Id_negocio == 3)
        //    {
        //        lote lot = new lote(_id_lote);
        //        tipo_cambio tc = new tipo_cambio(DateTime.Now);
        //        string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
        //        ////////////////INVENTARIOS////////////////
        //        decimal costo_lote = _superficie_m2 * _costo_m2_sus * tc.compra;
        //        manzano man = new manzano(_id_manzano);
        //        urbanizacion urb = new urbanizacion(man.id_urbanizacion);
        //        string nombre_urbanizacion = "";
        //        nombre_urbanizacion = urb.nombre.Trim().Replace("\"", "").Replace("(", " ").Replace(")", " ").Replace(".", " ").Replace("/", "").Replace("-", " ").Replace(",", ".") + " " + man.codigo.Trim() + " " + _codigo.Trim();
        //        ServiceReference1.SintesisService obj = new ServiceReference1.SintesisService();
        //        string resultado = obj.insertarMovimientosOdoo(3, true, "0", "", _id_lote.ToString(), 0, true, "INVENTARIO CREACION DE LOTES",
        //            0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, 0, true, urb.id_urbanizacion.ToString(), "", "", true, true, nombre_urbanizacion, "", false, true, context_id_usuario,
        //            true, ip, DateTime.Now.ToShortDateString(), costo_lote, true, 0, true, 0, true);

        //    }
        //}
    }

    protected void ddlUrbanizacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        odsManzano.DataBind();
        ddlManzano.DataBind();
    }

    protected void ddlManzano_SelectedIndexChanged(object sender, EventArgs e)
    {
        odsLote.DataBind();
        cblLote.DataBind();
        
    }
}

