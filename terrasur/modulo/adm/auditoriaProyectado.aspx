<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    public static DataTable tabla_contratos()
    {
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        DbCommand cmd = db1.GetStoredProcCommand("auditoria_proyectado");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        return db1.ExecuteDataSet(cmd).Tables[0];
    }

    public static DataTable obtener_datos()
    {
        DataTable tabla = tabla_contratos();

        int ene_ago_num_cuotas = 0; 
        decimal ene_ago_amortizacion = 0; 
        decimal ene_ago_seguro = 0; 
        decimal ene_ago_mantenimiento_sus = 0; 
        decimal ene_ago_interes_corriente = 0; 
        decimal ene_ago_monto_pago = 0;

        int sep_num_cuotas = 0;
        decimal sep_amortizacion = 0;
        decimal sep_seguro = 0;
        decimal sep_mantenimiento_sus = 0;
        decimal sep_interes_corriente = 0;
        decimal sep_monto_pago = 0;

        int oct_num_cuotas = 0;
        decimal oct_amortizacion = 0;
        decimal oct_seguro = 0;
        decimal oct_mantenimiento_sus = 0;
        decimal oct_interes_corriente = 0;
        decimal oct_monto_pago = 0;

        int nov_num_cuotas = 0;
        decimal nov_amortizacion = 0;
        decimal nov_seguro = 0;
        decimal nov_mantenimiento_sus = 0;
        decimal nov_interes_corriente = 0;
        decimal nov_monto_pago = 0;

        int dic_num_cuotas = 0;
        decimal dic_amortizacion = 0;
        decimal dic_seguro = 0;
        decimal dic_mantenimiento_sus = 0;
        decimal dic_interes_corriente = 0;
        decimal dic_monto_pago = 0;

        tabla.Columns.Add("ene_ago_num_cuotas", typeof(int));
        tabla.Columns.Add("ene_ago_amortizacion", typeof(decimal));
        tabla.Columns.Add("ene_ago_seguro", typeof(decimal));
        tabla.Columns.Add("ene_ago_mantenimiento_sus", typeof(decimal));
        tabla.Columns.Add("ene_ago_interes_corriente", typeof(decimal));
        tabla.Columns.Add("ene_ago_monto_pago", typeof(decimal));

        tabla.Columns.Add("sep_num_cuotas", typeof(int));
        tabla.Columns.Add("sep_amortizacion", typeof(decimal));
        tabla.Columns.Add("sep_seguro", typeof(decimal));
        tabla.Columns.Add("sep_mantenimiento_sus", typeof(decimal));
        tabla.Columns.Add("sep_interes_corriente", typeof(decimal));
        tabla.Columns.Add("sep_monto_pago", typeof(decimal));

        tabla.Columns.Add("oct_num_cuotas", typeof(int));
        tabla.Columns.Add("oct_amortizacion", typeof(decimal));
        tabla.Columns.Add("oct_seguro", typeof(decimal));
        tabla.Columns.Add("oct_mantenimiento_sus", typeof(decimal));
        tabla.Columns.Add("oct_interes_corriente", typeof(decimal));
        tabla.Columns.Add("oct_monto_pago", typeof(decimal));

        tabla.Columns.Add("nov_num_cuotas", typeof(int));
        tabla.Columns.Add("nov_amortizacion", typeof(decimal));
        tabla.Columns.Add("nov_seguro", typeof(decimal));
        tabla.Columns.Add("nov_mantenimiento_sus", typeof(decimal));
        tabla.Columns.Add("nov_interes_corriente", typeof(decimal));
        tabla.Columns.Add("nov_monto_pago", typeof(decimal));

        tabla.Columns.Add("dic_num_cuotas", typeof(int));
        tabla.Columns.Add("dic_amortizacion", typeof(decimal));
        tabla.Columns.Add("dic_seguro", typeof(decimal));
        tabla.Columns.Add("dic_mantenimiento_sus", typeof(decimal));
        tabla.Columns.Add("dic_interes_corriente", typeof(decimal));
        tabla.Columns.Add("dic_monto_pago", typeof(decimal));

        foreach (DataRow fila in tabla.Rows)
        {
            PagosRestantes_Gestion2011((DateTime)fila["fecha_reversion"], (DateTime)fila["fecha_saldo_cancelado"],
                ref ene_ago_num_cuotas, ref ene_ago_amortizacion, ref ene_ago_seguro, ref ene_ago_mantenimiento_sus, ref ene_ago_interes_corriente, ref ene_ago_monto_pago,
                ref sep_num_cuotas, ref sep_amortizacion, ref sep_seguro, ref sep_mantenimiento_sus, ref sep_interes_corriente, ref sep_monto_pago,
                ref oct_num_cuotas, ref oct_amortizacion, ref oct_seguro, ref oct_mantenimiento_sus, ref oct_interes_corriente, ref oct_monto_pago,
                ref nov_num_cuotas, ref nov_amortizacion, ref nov_seguro, ref nov_mantenimiento_sus, ref nov_interes_corriente, ref nov_monto_pago,
                ref dic_num_cuotas, ref dic_amortizacion, ref dic_seguro, ref dic_mantenimiento_sus, ref dic_interes_corriente, ref dic_monto_pago,

                (decimal)fila["interes_corriente"], (decimal)fila["mantenimiento_sus"], (decimal)fila["seguro"], (decimal)fila["cuota_base"], (DateTime)fila["fecha_inicio_plan"],
                (int)fila["id_ultimo_pago"]
                , (DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"]
                , (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"]
                , (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]);

            fila["ene_ago_num_cuotas"] = ene_ago_num_cuotas;
            fila["ene_ago_amortizacion"] = ene_ago_amortizacion;
            fila["sep_seguro"] = sep_seguro;
            fila["ene_ago_mantenimiento_sus"] = ene_ago_mantenimiento_sus;
            fila["ene_ago_interes_corriente"] = ene_ago_interes_corriente;
            fila["ene_ago_monto_pago"] = ene_ago_monto_pago;

            fila["sep_num_cuotas"] = sep_num_cuotas;
            fila["sep_amortizacion"] = sep_amortizacion;
            fila["sep_seguro"] = sep_seguro;
            fila["sep_mantenimiento_sus"] = sep_mantenimiento_sus;
            fila["sep_interes_corriente"] = sep_interes_corriente;
            fila["sep_monto_pago"] = sep_monto_pago;

            fila["oct_num_cuotas"] = oct_num_cuotas;
            fila["oct_amortizacion"] = oct_amortizacion;
            fila["oct_seguro"] = oct_seguro;
            fila["oct_mantenimiento_sus"] = oct_mantenimiento_sus;
            fila["oct_interes_corriente"] = oct_interes_corriente;
            fila["oct_monto_pago"] = oct_monto_pago;

            fila["nov_num_cuotas"] = nov_num_cuotas;
            fila["nov_amortizacion"] = nov_amortizacion;
            fila["nov_seguro"] = nov_seguro;
            fila["nov_mantenimiento_sus"] = nov_mantenimiento_sus;
            fila["nov_interes_corriente"] = nov_interes_corriente;
            fila["nov_monto_pago"] = nov_monto_pago;

            fila["dic_num_cuotas"] = dic_num_cuotas;
            fila["dic_amortizacion"] = dic_amortizacion;
            fila["dic_seguro"] = dic_seguro;
            fila["dic_mantenimiento_sus"] = dic_mantenimiento_sus;
            fila["dic_interes_corriente"] = dic_interes_corriente;
            fila["dic_monto_pago"] = dic_monto_pago;
        }
        return tabla;
    }

    public static void PagosRestantes_Gestion2011(DateTime Fecha_reversion, DateTime Fecha_saldo_cancelado,
    ref int ene_ago_num_cuotas, ref decimal ene_ago_amortizacion, ref decimal ene_ago_seguro, ref decimal ene_ago_mantenimiento_sus, ref decimal ene_ago_interes_corriente, ref decimal ene_ago_monto_pago,
    ref int sep_num_cuotas, ref decimal sep_amortizacion, ref decimal sep_seguro, ref decimal sep_mantenimiento_sus, ref decimal sep_interes_corriente, ref decimal sep_monto_pago,
    ref int oct_num_cuotas, ref decimal oct_amortizacion, ref decimal oct_seguro, ref decimal oct_mantenimiento_sus, ref decimal oct_interes_corriente, ref decimal oct_monto_pago,
    ref int nov_num_cuotas, ref decimal nov_amortizacion, ref decimal nov_seguro, ref decimal nov_mantenimiento_sus, ref decimal nov_interes_corriente, ref decimal nov_monto_pago,
    ref int dic_num_cuotas, ref decimal dic_amortizacion, ref decimal dic_seguro, ref decimal dic_mantenimiento_sus, ref decimal dic_interes_corriente, ref decimal dic_monto_pago,

    decimal pp_interes_corriente, decimal pp_mantenimiento_sus, decimal pp_seguro, decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, int Id_ultimo_pago

    , DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha
    , decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes
    , int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo)
    {
        ene_ago_num_cuotas = 0; ene_ago_amortizacion = 0; ene_ago_seguro = 0; ene_ago_mantenimiento_sus = 0; ene_ago_interes_corriente = 0; ene_ago_monto_pago = 0;
        sep_num_cuotas = 0; sep_amortizacion = 0; sep_seguro = 0; sep_mantenimiento_sus = 0; sep_interes_corriente = 0; sep_monto_pago = 0;
        oct_num_cuotas = 0; oct_amortizacion = 0; oct_seguro = 0; oct_mantenimiento_sus = 0; oct_interes_corriente = 0; oct_monto_pago = 0;
        nov_num_cuotas = 0; nov_amortizacion = 0; nov_seguro = 0; nov_mantenimiento_sus = 0; nov_interes_corriente = 0; nov_monto_pago = 0;
        dic_num_cuotas = 0; dic_amortizacion = 0; dic_seguro = 0; dic_mantenimiento_sus = 0; dic_interes_corriente = 0; dic_monto_pago = 0;

        sim_pago pago_simulado = new sim_pago(p_fecha, p_fecha_proximo, p_num_cuotas, p_seguro, p_seguro_meses, p_seguro_fecha
            , p_mantenimiento_sus, p_mantenimiento_meses, p_mantenimiento_fecha, p_interes
            , p_interes_dias, p_interes_dias_total, p_interes_fecha, p_monto_pago, p_amortizacion, p_saldo);


        //Se suman también todas las cuotas iniciales
        if (p_fecha >= DateTime.Parse("01/01/2011"))
        {
            if (p_fecha < DateTime.Parse("01/09/2011"))
            {
                //Pagos entre enero y agosto
                ene_ago_num_cuotas += 1;
                ene_ago_amortizacion += pago_simulado.amortizacion;
                ene_ago_seguro += pago_simulado.seguro;
                ene_ago_mantenimiento_sus += pago_simulado.mantenimiento_sus;
                ene_ago_interes_corriente += pago_simulado.interes;
                ene_ago_monto_pago += pago_simulado.monto_pago;
            }
            if (DateTime.Parse("01/09/2011") <= p_fecha && p_fecha < DateTime.Parse("01/10/2011"))
            {
                //Pagos en septiembre
                sep_num_cuotas += 1;
                sep_amortizacion += pago_simulado.amortizacion;
                sep_seguro += pago_simulado.seguro;
                sep_mantenimiento_sus += pago_simulado.mantenimiento_sus;
                sep_interes_corriente += pago_simulado.interes;
                sep_monto_pago += pago_simulado.monto_pago;
            }
            if (DateTime.Parse("01/10/2011") <= p_fecha && p_fecha < DateTime.Parse("01/11/2011"))
            {
                //Pagos en octubre
                oct_num_cuotas += 1;
                oct_amortizacion += pago_simulado.amortizacion;
                oct_seguro += pago_simulado.seguro;
                oct_mantenimiento_sus += pago_simulado.mantenimiento_sus;
                oct_interes_corriente += pago_simulado.interes;
                oct_monto_pago += pago_simulado.monto_pago;
            }
            if (DateTime.Parse("01/11/2011") <= p_fecha && p_fecha < DateTime.Parse("01/12/2011"))
            {
                //Pagos en noviembre
                nov_num_cuotas += 1;
                nov_amortizacion += pago_simulado.amortizacion;
                nov_seguro += pago_simulado.seguro;
                nov_mantenimiento_sus += pago_simulado.mantenimiento_sus;
                nov_interes_corriente += pago_simulado.interes;
                nov_monto_pago += pago_simulado.monto_pago;
            }
            if (p_fecha >= DateTime.Parse("01/12/2011"))
            {
                //Pagos en diciembre hacia adelante
                dic_num_cuotas += 1;
                dic_amortizacion += pago_simulado.amortizacion;
                dic_seguro += pago_simulado.seguro;
                dic_mantenimiento_sus += pago_simulado.mantenimiento_sus;
                dic_interes_corriente += pago_simulado.interes;
                dic_monto_pago += pago_simulado.monto_pago;
            }
        }


        DateTime Fecha_pago;
        if (pp_cuota_base == 0 && pago_simulado.saldo > 0) pp_cuota_base = pago_simulado.saldo;
        //while (pago_simulado.saldo > 0 && pago_simulado.fecha_proximo < Fecha_reversion)
        Fecha_reversion = Fecha_reversion.Date.AddDays((Fecha_reversion.Day - 1) * (-1));
        Fecha_saldo_cancelado = Fecha_saldo_cancelado.Date.AddDays(Convert.ToDouble(1));
        while (pago_simulado.saldo > 0 && pago_simulado.fecha_proximo < Fecha_reversion && pago_simulado.fecha_proximo < Fecha_saldo_cancelado)
        {
            Fecha_pago = pago_simulado.fecha_proximo;
            pago_simulado = new sim_pago(pago_simulado, Fecha_pago, 1, pp_cuota_base, pp_fecha_inicio_plan, pp_seguro, pp_mantenimiento_sus, pp_interes_corriente);


            //if (DateTime.Parse("01/01/2011") <= Fecha_pago && Fecha_pago < DateTime.Parse("01/09/2011"))
            if (Fecha_pago < DateTime.Parse("01/09/2011"))
            {
                //Pagos entre enero y agosto
                ene_ago_num_cuotas += 1;
                ene_ago_amortizacion += pago_simulado.amortizacion;
                ene_ago_seguro += pago_simulado.seguro;
                ene_ago_mantenimiento_sus += pago_simulado.mantenimiento_sus;
                ene_ago_interes_corriente += pago_simulado.interes;
                ene_ago_monto_pago += pago_simulado.monto_pago;
            }
            if (DateTime.Parse("01/09/2011") <= Fecha_pago && Fecha_pago < DateTime.Parse("01/10/2011"))
            {
                //Pagos en septiembre
                sep_num_cuotas += 1;
                sep_amortizacion += pago_simulado.amortizacion;
                sep_seguro += pago_simulado.seguro;
                sep_mantenimiento_sus += pago_simulado.mantenimiento_sus;
                sep_interes_corriente += pago_simulado.interes;
                sep_monto_pago += pago_simulado.monto_pago;
            }
            if (DateTime.Parse("01/10/2011") <= Fecha_pago && Fecha_pago < DateTime.Parse("01/11/2011"))
            {
                //Pagos en octubre
                oct_num_cuotas += 1;
                oct_amortizacion += pago_simulado.amortizacion;
                oct_seguro += pago_simulado.seguro;
                oct_mantenimiento_sus += pago_simulado.mantenimiento_sus;
                oct_interes_corriente += pago_simulado.interes;
                oct_monto_pago += pago_simulado.monto_pago;
            }
            if (DateTime.Parse("01/11/2011") <= Fecha_pago && Fecha_pago < DateTime.Parse("01/12/2011"))
            {
                //Pagos en noviembre
                nov_num_cuotas += 1;
                nov_amortizacion += pago_simulado.amortizacion;
                nov_seguro += pago_simulado.seguro;
                nov_mantenimiento_sus += pago_simulado.mantenimiento_sus;
                nov_interes_corriente += pago_simulado.interes;
                nov_monto_pago += pago_simulado.monto_pago;
            }
            if (Fecha_pago >= DateTime.Parse("01/12/2011"))
            {
                //Pagos en diciembre hacia adelante
                dic_num_cuotas += 1;
                dic_amortizacion += pago_simulado.amortizacion;
                dic_seguro += pago_simulado.seguro;
                dic_mantenimiento_sus += pago_simulado.mantenimiento_sus;
                dic_interes_corriente += pago_simulado.interes;
                dic_monto_pago += pago_simulado.monto_pago;
            }
        }
    }



    protected void btn_obtener_Click(object sender, EventArgs e)
    {
        DataTable tabla = obtener_datos();
        StringBuilder res = new StringBuilder();
        res.Append("numero,saldo_dic2010,saldo_ago2011,");
        res.Append("ene_ago_num_cuotas,ene_ago_monto_pago,ene_ago_amortizacion,ene_ago_interes_corriente,ene_ago_mantenimiento_sus,");
        res.Append("sep_num_cuotas,sep_monto_pago,sep_amortizacion,sep_interes_corriente,sep_mantenimiento_sus,");
        res.Append("oct_num_cuotas,oct_monto_pago,oct_amortizacion,oct_interes_corriente,oct_mantenimiento_sus,");
        res.Append("nov_num_cuotas,nov_monto_pago,nov_amortizacion,nov_interes_corriente,nov_mantenimiento_sus,");
        res.Append("dic_num_cuotas,dic_monto_pago,dic_amortizacion,dic_interes_corriente,dic_mantenimiento_sus;");
        
        foreach (DataRow fila in tabla.Rows)
        {
            res.Append(fila["numero"].ToString() + ",");
            res.Append(((decimal)fila["saldo_dic2010"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["saldo_ago2011"]).ToString("F2").Replace(',', '.') + ",");

            res.Append(fila["ene_ago_num_cuotas"].ToString() + ",");
            res.Append(((decimal)fila["ene_ago_monto_pago"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["ene_ago_amortizacion"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["ene_ago_interes_corriente"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["ene_ago_mantenimiento_sus"]).ToString("F2").Replace(',', '.') + ",");
            //res.Append(((decimal)fila["ene_ago_seguro"]).ToString("F2").Replace(',', '.') + ","); 

            res.Append(fila["sep_num_cuotas"].ToString() + ",");
            res.Append(((decimal)fila["sep_monto_pago"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["sep_amortizacion"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["sep_interes_corriente"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["sep_mantenimiento_sus"]).ToString("F2").Replace(',', '.') + ",");
            //res.Append(((decimal)fila["sep_seguro"]).ToString("F2").Replace(',', '.') + ",");

            res.Append(fila["oct_num_cuotas"].ToString() + ",");
            res.Append(((decimal)fila["oct_monto_pago"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["oct_amortizacion"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["oct_interes_corriente"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["oct_mantenimiento_sus"]).ToString("F2").Replace(',', '.') + ",");
            //res.Append(((decimal)fila["oct_seguro"]).ToString("F2").Replace(',', '.') + ",");

            res.Append(fila["nov_num_cuotas"].ToString() + ",");
            res.Append(((decimal)fila["nov_monto_pago"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["nov_amortizacion"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["nov_interes_corriente"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["nov_mantenimiento_sus"]).ToString("F2").Replace(',', '.') + ",");
            //res.Append(((decimal)fila["nov_seguro"]).ToString("F2").Replace(',', '.') + ",");

            res.Append(fila["dic_num_cuotas"].ToString() + ",");
            res.Append(((decimal)fila["dic_monto_pago"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["dic_amortizacion"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["dic_interes_corriente"]).ToString("F2").Replace(',', '.') + ",");
            res.Append(((decimal)fila["dic_mantenimiento_sus"]).ToString("F2").Replace(',', '.') + ",");
            //res.Append(((decimal)fila["dic_seguro"]).ToString("F2").Replace(',', '.') + ",");

            res.Append(";");
        }

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "text/csv";
        Response.AddHeader("Content-Disposition", "attachment;filename=PagosProyectados_EneAgo_Sep_Oct_Nov" + ".csv");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(res.ToString().TrimEnd(';').Replace(";", char.ConvertFromUtf32(13) + char.ConvertFromUtf32(10)).Replace(",", ";"));
        Response.End();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_obtener" runat="server" Text="Obtener" OnClick="btn_obtener_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
