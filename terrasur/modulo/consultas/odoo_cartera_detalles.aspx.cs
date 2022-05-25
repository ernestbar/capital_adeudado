using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using terrasur;
using System.Data;

    public partial class modulo_consultas_odoo_cartera_detalles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["trans_id"] != null)
                {
                   
                    string id_tran = Request.QueryString["trans_id"];
                    DataTable dt = transaccion.datos_para_odoo(int.Parse(id_tran));
                    if (dt.Rows.Count>0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            lblContrato.Text = dr["numero"].ToString();
                            lblUrb.Text = dr["urbanizacion"].ToString();
                            lblMzno.Text = dr["manzano"].ToString();
                            lblLote.Text = dr["lote"].ToString();
                            lblMoneda.Text=dr["moneda"].ToString();
                            decimal tipo_cambio, monto_aux, capital_aux, interes_aux;
                            tipo_cambio = (decimal)dr["tipo_cambio"];
                            monto_aux = (decimal)dr["monto"];
                            capital_aux = (decimal)dr["capital"];
                            interes_aux = (decimal)dr["interes"];
                            if (lblMoneda.Text.Trim() == "$us")
                            {
                                lblMonto_sus.Text = monto_aux.ToString("F2");
                                lblCapital_sus.Text = capital_aux.ToString("F2");
                                lblInteres_sus.Text = interes_aux.ToString("F2");
                                lblMonto_bs.Text = (monto_aux * tipo_cambio).ToString("F2");
                                lblCapital_bs.Text = (capital_aux * tipo_cambio).ToString("F2");
                                lblInteres_bs.Text = (interes_aux * tipo_cambio).ToString("F2");
                            }
                            else
                            {
                                lblMonto_sus.Text = (monto_aux / tipo_cambio).ToString("F2");
                                lblCapital_sus.Text = (capital_aux / tipo_cambio).ToString("F2");
                                lblInteres_sus.Text = (interes_aux / tipo_cambio).ToString("F2");

                                lblMonto_bs.Text = monto_aux.ToString("F2");
                                lblCapital_bs.Text = capital_aux.ToString("F2");
                                lblInteres_bs.Text = interes_aux.ToString("F2");
                            }
                            lblTipoPago.Text=dr["tipo_pago"].ToString();
                            lblFactura.Text=dr["nro_factura"].ToString();
                            lblRecibo.Text = dr["nro_recibo"].ToString();
                            lblDpr.Text = dr["DPR"].ToString();
                            lblFecha.Text=dr["fecha_pago"].ToString();
                            lblSucursal.Text=dr["sucursal"].ToString();
                            lblTc.Text=dr["tipo_cambio"].ToString();
                        }
                    }
                    else
                    {

                        lblContrato.Text = "NO EXISTEN DATOS PARA MOSTRAR";
                        lblUrb.Text = "";
                        lblLote.Text = "";
                        lblMzno.Text = "";
                    }


                }
            }


        }

    }

