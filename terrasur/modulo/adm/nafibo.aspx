<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Reportes Nafibo - Ejecutado y Proyectado" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>
<%--<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>--%>

<script runat="server">
    public static DataTable Ejecutado(DateTime Inicio, DateTime Fin, bool Solo_pagos)
    {
        //[id_transaccion],[fecha],[id_contrato],[fecha_ejecutado],[institucion],[num_contrato],
        //[concepto],[num_cuota],[fecha_pago],[interes],[capital],[monto],[fuera_de_hora]
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        DbCommand cmd = db1.GetStoredProcCommand("nafibo_ejecutado_proyectado");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "ejecutado", DbType.Boolean, true);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, null);
        db1.AddInParameter(cmd, "inicio", DbType.DateTime, Inicio);
        db1.AddInParameter(cmd, "fin", DbType.DateTime, Fin);
        db1.AddInParameter(cmd, "solo_pagos", DbType.Boolean, Solo_pagos);
        return db1.ExecuteDataSet(cmd).Tables[0];
    }
    public static void AjusteEjecutado(ref DataTable tabla_ejecutado, DateTime Fecha)
    {
        //Se obtiene la tabla de ejecutados esencial ([id_contrato],[num_cuota_menor])
        DataTable tabla_ejecutado_esencial = new DataTable();
        tabla_ejecutado_esencial.Columns.Add("id_contrato", typeof(int));
        tabla_ejecutado_esencial.Columns.Add("num_cuota_menor", typeof(int));
        foreach (DataRow fila in tabla_ejecutado.Rows)
        {
            int id_contrato = (int)fila["id_contrato"];
            int num_cuota = (int)fila["num_cuota"];
            int index_esencial = -1;
            for (int j = 0; j < tabla_ejecutado_esencial.Rows.Count; j++)
            {
                if (((int)tabla_ejecutado_esencial.Rows[j]["id_contrato"]) == id_contrato)
                {
                    index_esencial = j;
                    break;
                }
            }
            if (index_esencial >= 0)
            {
                if (num_cuota < ((int)tabla_ejecutado_esencial.Rows[index_esencial]["num_cuota_menor"]))
                    tabla_ejecutado_esencial.Rows[index_esencial]["num_cuota_menor"] = num_cuota;
            }
            else
            {
                DataRow fila_ejecutado_esencial = tabla_ejecutado_esencial.NewRow();
                fila_ejecutado_esencial["id_contrato"] = id_contrato;
                fila_ejecutado_esencial["num_cuota_menor"] = num_cuota;
                tabla_ejecutado_esencial.Rows.Add(fila_ejecutado_esencial);
            }
        }

        //Se obtine la tabla de ajuste almacenada
        //[id_contrato],[num_cuota]
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        DbCommand cmd = db1.GetStoredProcCommand("ajuste_cuota_nafibo_Fecha");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
        DataTable tabla_ajuste_almacenada = db1.ExecuteDataSet(cmd).Tables[0];
        
        //Se obtiene la tabla de ajuste a aplicarse
        DataTable tabla_ajuste = new DataTable();
        tabla_ajuste.Columns.Add("id_contrato", typeof(int));
        tabla_ajuste.Columns.Add("diferencia", typeof(int));
        foreach (DataRow fila_almacenada in tabla_ajuste_almacenada.Rows)
        {
            int id_contrato = (int)fila_almacenada["id_contrato"];
            int num_cuota = (int)fila_almacenada["num_cuota"];

            int diferencia = 0;
            foreach (DataRow fila_esencial in tabla_ejecutado_esencial.Rows)
            {
                if (((int)fila_esencial["id_contrato"]) == id_contrato)
                {
                    diferencia = (num_cuota + 1) - ((int)fila_esencial["num_cuota_menor"]);
                    break;
                }
            }
            if (diferencia != 0)
            {
                DataRow fila_ajuste = tabla_ajuste.NewRow();
                fila_ajuste["id_contrato"] = id_contrato;
                fila_ajuste["diferencia"] = diferencia;
                tabla_ajuste.Rows.Add(fila_ajuste);
            }
        }
        
        //Se realizan los ajustes en la tabla de ejecutados
        foreach (DataRow fila_ajuste in tabla_ajuste.Rows)
        {
            int id_contrato = (int)fila_ajuste["id_contrato"];
            int diferencia = (int)fila_ajuste["diferencia"];
            foreach (DataRow fila in tabla_ejecutado.Rows)
                if (((int)fila["id_contrato"]) == id_contrato)
                    fila["num_cuota"] = ((int)fila["num_cuota"]) + diferencia;
        }
    }

    protected void Mostrar_ejecutado()
    {
        DataTable tabla = Ejecutado(cp_inicio.SelectedDate, cp_fin.SelectedDate, bool.Parse(rbl_solo_pagos.SelectedValue));
        if (cb_ajuste.Checked == true) { AjusteEjecutado(ref tabla, cp_fin.SelectedDate); }
        tabla.Columns.Remove("id_transaccion");
        tabla.Columns.Remove("fecha");
        tabla.Columns.Remove("id_contrato");
        if (bool.Parse(rbl_solo_pagos.SelectedValue) == true) tabla.Columns.Remove("concepto");

        string cap_int = "_CapitalInteres";
        if (bool.Parse(rbl_solo_pagos.SelectedValue) == true) cap_int = "_MontoPagado";
        ExportarExcel(tabla, "Nafibo_Ejecutado_" + cp_inicio.SelectedDate.ToString("d").Replace("/", "") + "_" + cp_fin.SelectedDate.ToString("d").Replace("/", "") + cap_int);
    }






    public static DataTable TablaAjustesNumCuotas(DateTime Fecha_inicio, DateTime Fecha_fin)
    {
        DataTable tabla_original = Ejecutado(Fecha_inicio, Fecha_fin, true);
        DataTable tabla_ajustada = new DataTable(); tabla_ajustada.Columns.Add("id_contrato", typeof(int)); tabla_ajustada.Columns.Add("num_cuota", typeof(int));
        foreach (DataRow fila in tabla_original.Rows)
        {
            DataRow fila_ajustada = tabla_ajustada.NewRow(); fila_ajustada["id_contrato"] = ((int)fila["id_contrato"]); fila_ajustada["num_cuota"] = ((int)fila["num_cuota"]);
            tabla_ajustada.Rows.Add(fila_ajustada);
        }
        AjusteEjecutado(ref tabla_ajustada, Fecha_fin);

        //Se obtiene la tabla de original esencial
        DataTable tabla_original_esencial = new DataTable();
        tabla_original_esencial.Columns.Add("id_contrato", typeof(int));
        tabla_original_esencial.Columns.Add("num_cuota_mayor", typeof(int));
        foreach (DataRow fila in tabla_original.Rows)
        {
            int id_contrato = (int)fila["id_contrato"];
            int num_cuota = (int)fila["num_cuota"];
            int index_esencial = -1;
            for (int j = 0; j < tabla_original_esencial.Rows.Count; j++)
            {
                if (((int)tabla_original_esencial.Rows[j]["id_contrato"]) == id_contrato)
                {
                    index_esencial = j;
                    break;
                }
            }
            if (index_esencial >= 0)
            {
                if (num_cuota > ((int)tabla_original_esencial.Rows[index_esencial]["num_cuota_mayor"]))
                    tabla_original_esencial.Rows[index_esencial]["num_cuota_mayor"] = num_cuota;
            }
            else
            {
                DataRow fila_original_esencial = tabla_original_esencial.NewRow();
                fila_original_esencial["id_contrato"] = id_contrato;
                fila_original_esencial["num_cuota_mayor"] = num_cuota;
                tabla_original_esencial.Rows.Add(fila_original_esencial);
            }
        }

        //Se obtiene la tabla de ajustada esencial
        DataTable tabla_ajustada_esencial = new DataTable();
        tabla_ajustada_esencial.Columns.Add("id_contrato", typeof(int));
        tabla_ajustada_esencial.Columns.Add("num_cuota_mayor", typeof(int));
        foreach (DataRow fila in tabla_ajustada.Rows)
        {
            int id_contrato = (int)fila["id_contrato"];
            int num_cuota = (int)fila["num_cuota"];
            int index_esencial = -1;
            for (int j = 0; j < tabla_ajustada_esencial.Rows.Count; j++)
            {
                if (((int)tabla_ajustada_esencial.Rows[j]["id_contrato"]) == id_contrato)
                {
                    index_esencial = j;
                    break;
                }
            }
            if (index_esencial >= 0)
            {
                if (num_cuota > ((int)tabla_ajustada_esencial.Rows[index_esencial]["num_cuota_mayor"]))
                    tabla_ajustada_esencial.Rows[index_esencial]["num_cuota_mayor"] = num_cuota;
            }
            else
            {
                DataRow fila_ajustada_esencial = tabla_ajustada_esencial.NewRow();
                fila_ajustada_esencial["id_contrato"] = id_contrato;
                fila_ajustada_esencial["num_cuota_mayor"] = num_cuota;
                tabla_ajustada_esencial.Rows.Add(fila_ajustada_esencial);
            }
        }

        //Se construye la tabla de ajustes
        DataTable tabla_ajustes = new DataTable();
        tabla_ajustes.Columns.Add("id_contrato", typeof(int));
        tabla_ajustes.Columns.Add("num_cuota", typeof(int));

        foreach (DataRow fila in tabla_original_esencial.Rows)
        {
            int id_contrato = (int)fila["id_contrato"];
            int num_cuota_mayor = (int)fila["num_cuota_mayor"];
            int index_esencial = -1;
            for (int j = 0; j < tabla_ajustada_esencial.Rows.Count; j++)
            {
                if (((int)tabla_ajustada_esencial.Rows[j]["id_contrato"]) == id_contrato)
                {
                    index_esencial = j;
                    break;
                }
            }
            if (num_cuota_mayor != ((int)tabla_ajustada_esencial.Rows[index_esencial]["num_cuota_mayor"]))
            {
                DataRow fila_ajustes = tabla_ajustes.NewRow();
                fila_ajustes["id_contrato"] = id_contrato;
                fila_ajustes["num_cuota"] = ((int)tabla_ajustada_esencial.Rows[index_esencial]["num_cuota_mayor"]);
                tabla_ajustes.Rows.Add(fila_ajustes);
            }
        }

        //Se localizan los Nº de cuota ajustados en el presente periodo
        //[id_contrato],[num_cuota]
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        DbCommand cmd = db1.GetStoredProcCommand("ajuste_cuota_nafibo_TablaCuotasSistema");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha_fin.Date);
        DataTable tabla_num_cuotas = db1.ExecuteDataSet(cmd).Tables[0];

        foreach (DataRow fila_ajustada_esencial in tabla_ajustada_esencial.Rows)
        {
            int id_contrato = (int)fila_ajustada_esencial["id_contrato"];
            int num_cuota_mayor = (int)fila_ajustada_esencial["num_cuota_mayor"];
            foreach (DataRow fila_num_cuotas in tabla_num_cuotas.Rows)
            {
                if (((int)fila_num_cuotas["id_contrato"]) == id_contrato)
                {
                    if (((int)fila_num_cuotas["num_cuota"]) != num_cuota_mayor || ((int)fila_num_cuotas["num_ajustes"]) > 0)
                    {
                        DataRow fila_ajustes = tabla_ajustes.NewRow();
                        fila_ajustes["id_contrato"] = id_contrato;
                        fila_ajustes["num_cuota"] = num_cuota_mayor;
                        tabla_ajustes.Rows.Add(fila_ajustes);
                    }
                    break;
                }
            }
        }

        
        return tabla_ajustes;
    }
    public static bool GuardarAjustesNumCuotas(DateTime Fecha_inicio, DateTime Fecha_fin)
    {
        //[id_contrato],[num_cuota]
        DataTable tabla_ajustes = TablaAjustesNumCuotas(Fecha_inicio, Fecha_fin);
        bool correcto = true;
        foreach (DataRow fila_ajuste in tabla_ajustes.Rows)
        {
            int id_contrato = (int)fila_ajuste["id_contrato"];
            int num_cuota = (int)fila_ajuste["num_cuota"];
            try
            {
                Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

                DbCommand cmd = db1.GetStoredProcCommand("ajuste_cuota_nafibo_Guardar");
                cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
                db1.AddInParameter(cmd, "id_contrato", DbType.Int32, id_contrato);
                db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha_fin.Date);
                db1.AddInParameter(cmd, "num_cuota", DbType.Int32, num_cuota);
                db1.ExecuteNonQuery(cmd);
            }
            catch { correcto = false; break; }
        }
        return correcto;
    }

    protected void lb_guardar_ejecutado_Click(object sender, EventArgs e)
    {
        bool correcto = GuardarAjustesNumCuotas(cp_inicio.SelectedDate, cp_fin.SelectedDate);
        if (correcto == true) Msg1.Text = "Los ajustes se guardaron correctamente";
        else Msg1.Text = "Los ajustes NO se guardaron correctamente";
    }





    public static DataTable Proyectado(DateTime Fecha)
    {
        //[id_contrato],[numero]
        //[seguro],[mantenimiento_sus],[interes_corriente],[cuota_base],[fecha_inicio_plan]
        //[realizado_num_cuotas]

        //p_id_pago,p_fecha,p_fecha_proximo,p_num_cuotas,p_seguro,p_seguro_meses,p_seguro_fecha
        //p_mantenimiento_sus,p_mantenimiento_meses,p_mantenimiento_fecha,p_interes
        //p_interes_dias,p_interes_dias_total,p_interes_fecha,p_monto_pago,p_amortizacion,p_saldo
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        DbCommand cmd = db1.GetStoredProcCommand("nafibo_ejecutado_proyectado");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "ejecutado", DbType.Boolean, false);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
        db1.AddInParameter(cmd, "inicio", DbType.DateTime, null);
        db1.AddInParameter(cmd, "fin", DbType.DateTime, null);
        db1.AddInParameter(cmd, "solo_pagos", DbType.Boolean, null);
        return db1.ExecuteDataSet(cmd).Tables[0];
    }

    public static void AjusteProyectado(ref DataTable tabla_proyectado, DateTime Fecha)
    {
        //Se obtine la tabla de ajuste almacenada
        //[id_contrato],[num_cuota]
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        DbCommand cmd = db1.GetStoredProcCommand("ajuste_cuota_nafibo_Fecha");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha.AddDays(1));
        DataTable tabla_ajuste_almacenada = db1.ExecuteDataSet(cmd).Tables[0];

        //Se realizan los ajustes en la tabla de proyectados
        foreach (DataRow fila_ajuste in tabla_ajuste_almacenada.Rows)
        {
            int id_contrato = ((int)fila_ajuste["id_contrato"]);
            int num_cuota = ((int)fila_ajuste["num_cuota"]);

            foreach (DataRow fila_proyectado in tabla_proyectado.Rows)
            {
                if (((int)fila_proyectado["id_contrato"]) == id_contrato)
                {
                    fila_proyectado["realizado_num_cuotas"] = num_cuota;
                    break;
                }   
            }
        }
    }
    
    protected void Mostrar_proyectado()
    {
        DateTime fecha = cp_inicio.SelectedDate;
        bool capital_interes = bool.Parse(rbl_solo_pagos.SelectedValue).Equals(false);
        if (fecha.Day != DateTime.DaysInMonth(fecha.Year, fecha.Month))
            fecha = fecha.AddDays((-1) * fecha.Day).AddDays(DateTime.DaysInMonth(fecha.Year, fecha.Month));

        DataTable tabla = Proyectado(fecha);
        
        if (cb_ajuste.Checked == true) { AjusteProyectado(ref tabla, fecha); }

        DataTable tabla_res = new DataTable();
        tabla_res.Columns.Add("fecha_emision", typeof(string));
        tabla_res.Columns.Add("contrato", typeof(string));
        if (capital_interes == true) tabla_res.Columns.Add("concepto", typeof(string));
        tabla_res.Columns.Add("ncuota", typeof(string));
        tabla_res.Columns.Add("fecha_pago", typeof(string));
        tabla_res.Columns.Add("interes", typeof(decimal));
        tabla_res.Columns.Add("capital", typeof(decimal));
        tabla_res.Columns.Add("monto", typeof(decimal));

        foreach (DataRow fila in tabla.Rows)
        {
            string num_contrato = fila["numero"].ToString();
            decimal pp_seguro = (decimal)fila["seguro"];
            decimal pp_mantenimiento_sus = (decimal)fila["mantenimiento_sus"];
            decimal pp_interes_corriente = (decimal)fila["interes_corriente"];
            decimal pp_cuota_base = (decimal)fila["cuota_base"];
            DateTime pp_fecha_inicio_plan = (DateTime)fila["fecha_inicio_plan"];
            int realizado_num_cuotas = (int)fila["realizado_num_cuotas"];

            sim_pago pago_simulado = new sim_pago((DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"]
                , (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"]
                , (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]);

            DateTime fecha_prox_pago = fecha.AddDays(pp_fecha_inicio_plan.Day);

            pago_simulado = new sim_pago(pago_simulado, fecha_prox_pago, 1,
                pp_cuota_base, pp_fecha_inicio_plan, pp_seguro,
                pp_mantenimiento_sus, pp_interes_corriente);

            DataRow fila_cap_res = tabla_res.NewRow();
            fila_cap_res["fecha_emision"] = fecha.ToString("d");
            fila_cap_res["contrato"] = num_contrato;
            if (capital_interes == true) fila_cap_res["concepto"] = "CAP";
            fila_cap_res["ncuota"] = realizado_num_cuotas + pago_simulado.num_cuotas;
            fila_cap_res["fecha_pago"] = pago_simulado.fecha.ToString("d");

            fila_cap_res["interes"] = pago_simulado.interes;
            fila_cap_res["capital"] = pago_simulado.amortizacion;

            if (capital_interes == true) fila_cap_res["monto"] = pago_simulado.amortizacion;
            else fila_cap_res["monto"] = pago_simulado.monto_pago;

            tabla_res.Rows.Add(fila_cap_res);

            if (capital_interes == true)
            {
                DataRow fila_int_res = tabla_res.NewRow();
                fila_int_res["fecha_emision"] = fecha.ToString("d");
                fila_int_res["contrato"] = num_contrato;
                fila_int_res["concepto"] = "INT";
                fila_int_res["ncuota"] = realizado_num_cuotas + pago_simulado.num_cuotas;
                fila_int_res["fecha_pago"] = pago_simulado.fecha.ToString("d");
                fila_int_res["monto"] = pago_simulado.interes;
                tabla_res.Rows.Add(fila_int_res);
            }
        }
        string cap_int = "_CapitalInteres";

        if (bool.Parse(rbl_solo_pagos.SelectedValue) == false)
        {
            tabla_res.Columns.Remove("interes");
            tabla_res.Columns.Remove("capital");
        }
        if (bool.Parse(rbl_solo_pagos.SelectedValue) == true) cap_int = "_MontoPagado";
        ExportarExcel(tabla_res, "Nafibo_Proyectado_" + fecha.AddDays(1).ToString("MMM_yyyy") + cap_int);
    }




    
    protected void btn_obtener_Click(object sender, EventArgs e)
    {
        if (bool.Parse(rbl_ejecutado.SelectedValue) == true) Mostrar_ejecutado();
        else Mostrar_proyectado();
    }

    protected void rbl_ejecutado_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool ejecutado = bool.Parse(rbl_ejecutado.SelectedValue);
        lbl_periodo.Visible = ejecutado;
        cp_fin.Visible = ejecutado;
        lb_guardar_ejecutado.Visible = ejecutado;
        if (ejecutado == true) lbl_fecha.Text = "Periodo:";
        else lbl_fecha.Text = "Fecha de emisión:";
    }



    protected void Mostrar_ejecutado_Selectivo()
    {
        //[id_transaccion],[fecha],[id_contrato],[fecha_ejecutado],[institucion],[num_contrato],
        //[concepto],[num_cuota],[fecha_pago],[interes],[capital],[monto],[fuera_de_hora]
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        DbCommand cmd = db1.GetStoredProcCommand("nafibo_ejecutado_proyectado_selectivo");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "ejecutado", DbType.Boolean, true);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, null);
        db1.AddInParameter(cmd, "inicio", DbType.DateTime, cp_inicio.SelectedDate);
        db1.AddInParameter(cmd, "fin", DbType.DateTime, cp_fin.SelectedDate);
        db1.AddInParameter(cmd, "solo_pagos", DbType.Boolean, bool.Parse(rbl_solo_pagos.SelectedValue));
        db1.AddInParameter(cmd, "num_contratos", DbType.String, ',' + txt_contratos_selectivo.Text.Trim().TrimEnd(',').TrimStart(',') + ',');
        DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

        if (cb_ajuste.Checked == true) { AjusteEjecutado(ref tabla, cp_fin.SelectedDate); }
        tabla.Columns.Remove("id_transaccion");
        tabla.Columns.Remove("fecha");
        tabla.Columns.Remove("id_contrato");
        if (bool.Parse(rbl_solo_pagos.SelectedValue) == true) tabla.Columns.Remove("concepto");

        string cap_int = "_CapitalInteres";
        if (bool.Parse(rbl_solo_pagos.SelectedValue) == true) cap_int = "_MontoPagado";
        ExportarExcel(tabla, "Nafibo_Ejecutado_" + cp_inicio.SelectedDate.ToString("d").Replace("/", "") + "_" + cp_fin.SelectedDate.ToString("d").Replace("/", "") + cap_int);
    }


    protected void Mostrar_proyectado_Selectivo()
    {
        DateTime fecha = cp_inicio.SelectedDate;
        bool capital_interes = bool.Parse(rbl_solo_pagos.SelectedValue).Equals(false);
        if (fecha.Day != DateTime.DaysInMonth(fecha.Year, fecha.Month))
            fecha = fecha.AddDays((-1) * fecha.Day).AddDays(DateTime.DaysInMonth(fecha.Year, fecha.Month));

        
        //[id_contrato],[numero]
        //[seguro],[mantenimiento_sus],[interes_corriente],[cuota_base],[fecha_inicio_plan]
        //[realizado_num_cuotas]

        //p_id_pago,p_fecha,p_fecha_proximo,p_num_cuotas,p_seguro,p_seguro_meses,p_seguro_fecha
        //p_mantenimiento_sus,p_mantenimiento_meses,p_mantenimiento_fecha,p_interes
        //p_interes_dias,p_interes_dias_total,p_interes_fecha,p_monto_pago,p_amortizacion,p_saldo
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        DbCommand cmd = db1.GetStoredProcCommand("nafibo_ejecutado_proyectado_selectivo");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "ejecutado", DbType.Boolean, false);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, fecha);
        db1.AddInParameter(cmd, "inicio", DbType.DateTime, null);
        db1.AddInParameter(cmd, "fin", DbType.DateTime, null);
        db1.AddInParameter(cmd, "solo_pagos", DbType.Boolean, null);
        db1.AddInParameter(cmd, "num_contratos", DbType.String, ',' + txt_contratos_selectivo.Text.Trim().TrimEnd(',').TrimStart(',') + ',');
        DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];


        DataTable tabla_res = new DataTable();
        tabla_res.Columns.Add("fecha_emision", typeof(string));
        tabla_res.Columns.Add("contrato", typeof(string));
        if (capital_interes == true) tabla_res.Columns.Add("concepto", typeof(string));
        tabla_res.Columns.Add("ncuota", typeof(string));
        tabla_res.Columns.Add("fecha_pago", typeof(string));
        tabla_res.Columns.Add("interes", typeof(decimal));
        tabla_res.Columns.Add("capital", typeof(decimal));
        tabla_res.Columns.Add("monto", typeof(decimal));

        foreach (DataRow fila in tabla.Rows)
        {
            string num_contrato = fila["numero"].ToString();
            decimal pp_seguro = (decimal)fila["seguro"];
            decimal pp_mantenimiento_sus = (decimal)fila["mantenimiento_sus"];
            decimal pp_interes_corriente = (decimal)fila["interes_corriente"];
            decimal pp_cuota_base = (decimal)fila["cuota_base"];
            DateTime pp_fecha_inicio_plan = (DateTime)fila["fecha_inicio_plan"];
            int realizado_num_cuotas = (int)fila["realizado_num_cuotas"];

            sim_pago pago_simulado = new sim_pago((DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"]
                , (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"]
                , (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]);

            DateTime fecha_prox_pago = fecha.AddDays(pp_fecha_inicio_plan.Day);

            pago_simulado = new sim_pago(pago_simulado, fecha_prox_pago, 1,
                pp_cuota_base, pp_fecha_inicio_plan, pp_seguro,
                pp_mantenimiento_sus, pp_interes_corriente);

            DataRow fila_cap_res = tabla_res.NewRow();
            fila_cap_res["fecha_emision"] = fecha.ToString("d");
            fila_cap_res["contrato"] = num_contrato;
            if (capital_interes == true) fila_cap_res["concepto"] = "CAP";
            fila_cap_res["ncuota"] = realizado_num_cuotas + pago_simulado.num_cuotas;
            fila_cap_res["fecha_pago"] = pago_simulado.fecha.ToString("d");

            fila_cap_res["interes"] = pago_simulado.interes;
            fila_cap_res["capital"] = pago_simulado.amortizacion;

            if (capital_interes == true) fila_cap_res["monto"] = pago_simulado.amortizacion;
            else fila_cap_res["monto"] = pago_simulado.monto_pago;

            tabla_res.Rows.Add(fila_cap_res);

            if (capital_interes == true)
            {
                DataRow fila_int_res = tabla_res.NewRow();
                fila_int_res["fecha_emision"] = fecha.ToString("d");
                fila_int_res["contrato"] = num_contrato;
                fila_int_res["concepto"] = "INT";
                fila_int_res["ncuota"] = realizado_num_cuotas + pago_simulado.num_cuotas;
                fila_int_res["fecha_pago"] = pago_simulado.fecha.ToString("d");
                fila_int_res["monto"] = pago_simulado.interes;
                tabla_res.Rows.Add(fila_int_res);
            }
        }
        string cap_int = "_CapitalInteres";

        if (bool.Parse(rbl_solo_pagos.SelectedValue) == false)
        {
            tabla_res.Columns.Remove("interes");
            tabla_res.Columns.Remove("capital");
        }
        if (bool.Parse(rbl_solo_pagos.SelectedValue) == true) cap_int = "_MontoPagado";
        ExportarExcel(tabla_res, "Nafibo_Proyectado_" + fecha.AddDays(1).ToString("MMM_yyyy") + cap_int);
    }    
    
    protected void btn_obtener_selectivo_Click(object sender, EventArgs e)
    {
        if (bool.Parse(rbl_ejecutado.SelectedValue) == true) Mostrar_ejecutado_Selectivo();
        else Mostrar_proyectado_Selectivo();
    }

        
   
    
    
    protected void ExportarExcel(DataTable tabla, string nombre)
    {
        Response.Clear();
        foreach (DataColumn columna in tabla.Columns) Response.Write(columna.ColumnName + ";");
        Response.Write(Environment.NewLine);
        foreach (DataRow fila in tabla.Rows)
        {
            for (int i = 0; i < tabla.Columns.Count; i++)
                Response.Write(fila[i].ToString().Replace(";", string.Empty) + ";");
            Response.Write(Environment.NewLine);
        }
        Response.ContentType = "text/csv";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombre + ".csv");
        Response.End();    
    }

    protected void btn_formato_nafibo_Click(object sender, EventArgs e)
    {
        string numero_contrato = ',' + txt_formato_nafibo.Text.Trim().Trim(',') + ',';
        DateTime Fecha = cp_formato_nafibo.SelectedDate;

        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        DbCommand cmd = db1.GetStoredProcCommand("nafibo_FormatoNafibo");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
        db1.AddInParameter(cmd, "numero_contrato", DbType.String, numero_contrato);
        DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
        int Num_cuotas = 0; decimal Amortizacion = 0; decimal Seguro = 0; decimal Mantenimiento_sus = 0; decimal Interes_corriente = 0; decimal Monto_pago = 0;
        foreach (DataRow fila in tabla.Rows)
        {
            contabilidadReporte.PagosRestantes((int)fila["id_contrato"], Fecha, ref Num_cuotas,
                ref Amortizacion, ref Seguro, ref Mantenimiento_sus, ref Interes_corriente, ref Monto_pago,
                (decimal)fila["interes_corriente"], (decimal)fila["mantenimiento_sus"], (decimal)fila["seguro"], (decimal)fila["cuota_base"], (DateTime)fila["fecha_inicio_plan"],
                (int)fila["id_ultimo_pago"]
                , (DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"]
                , (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"]
                , (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]);
            fila["restante_num_cuotas"] = Num_cuotas;
            //fila["restante_amortizacion"] = Amortizacion;
            fila["restante_seguro"] = Seguro;
            fila["restante_mantenimiento"] = Mantenimiento_sus;
            fila["restante_interes"] = Interes_corriente;
            fila["restante_total"] = Monto_pago;

            fila["total_num_cuotas"] = (int)fila["realizado_num_cuotas"] + Num_cuotas;
            //fila["total_precio"] = (decimal)fila["realizado_amortizacion"] + Amortizacion;
            fila["total_seguro"] = (decimal)fila["realizado_seguro"] + Seguro;
            fila["total_mantenimiento"] = (decimal)fila["realizado_mantenimiento"] + Mantenimiento_sus;
            fila["total_interes"] = (decimal)fila["realizado_interes"] + Interes_corriente;
            fila["total_total"] = (decimal)fila["realizado_total"] + Monto_pago;
        }
        /*[id_contrato],[numero],[precio_final],[seguro],[mantenimiento_sus],[interes_corriente],
        [cuota_base],[fecha_inicio_plan],[id_ultimo_pago],[estado]
        [p_fecha],[p_fecha_proximo],[p_num_cuotas],[p_seguro],[p_seguro_meses],[p_seguro_fecha],[p_mantenimiento_sus],[p_mantenimiento_meses],[p_mantenimiento_fecha],[p_interes],[p_interes_dias],[p_interes_dias_total],[p_interes_fecha],[p_monto_pago],[p_amortizacion],[p_saldo]
        [realizado_num_cuotas],[realizado_amortizacion],[realizado_seguro],[realizado_mantenimiento],[realizado_interes],[realizado_total],
        [restante_num_cuotas],[restante_amortizacion],[restante_seguro],[restante_mantenimiento],[restante_interes],[restante_total],
        [total_num_cuotas],[total_precio],[total_seguro],[total_mantenimiento],[total_interes],[total_total]
        */
        DataTable tabla2 = new DataTable();
        tabla2.Columns.Add("num_row", typeof(int));
        tabla2.Columns.Add("num_contrato", typeof(string));
        tabla2.Columns.Add("num_cuotas_totales", typeof(int));
        tabla2.Columns.Add("num_cuotas_pagadas", typeof(int));
        tabla2.Columns.Add("num_cuotas_pendientes", typeof(int));
        tabla2.Columns.Add("fecha_vencimiento", typeof(string));
        tabla2.Columns.Add("total_pagado", typeof(decimal));
        tabla2.Columns.Add("monto_otorgado", typeof(decimal));
        tabla2.Columns.Add("estado", typeof(string));
        tabla2.Columns.Add("plazo", typeof(int));
        tabla2.Columns.Add("plazo_remanente", typeof(int));
        tabla2.Columns.Add("tasa_interes", typeof(decimal));
        tabla2.Columns.Add("monto_saldo", typeof(decimal));

        int num_row = 1;
        decimal num_dias_mes = Convert.ToDecimal((Convert.ToDouble(365) / Convert.ToDouble(12)));
        foreach (DataRow fila in tabla.Rows)
        {
            DataRow fila2 = tabla2.NewRow();
            fila2["num_row"] = num_row;
            fila2["num_contrato"] = fila["numero"].ToString();
            fila2["num_cuotas_totales"] = (int)fila["total_num_cuotas"];
            fila2["num_cuotas_pagadas"] = (int)fila["realizado_num_cuotas"];
            fila2["num_cuotas_pendientes"] = (int)fila["restante_num_cuotas"];
            decimal restante_num_cuotas = Convert.ToDecimal((int)fila["restante_num_cuotas"]);
            decimal aux_num_dias = restante_num_cuotas * num_dias_mes;
            //fila2["fecha_vencimiento"] = ((DateTime)fila["p_fecha"]).AddDays(Convert.ToDouble(aux_num_dias)).ToString("d");
            fila2["fecha_vencimiento"] = ((DateTime)fila["p_fecha_proximo"]).AddDays(Convert.ToDouble(aux_num_dias)).ToString("d");
            fila2["total_pagado"] = (decimal)fila["realizado_amortizacion"];
            fila2["monto_otorgado"] = (decimal)fila["precio_final"];
            fila2["estado"] = fila["estado"].ToString();
            fila2["plazo"] = (int)(((decimal)(int)fila["total_num_cuotas"]) * num_dias_mes);
            fila2["plazo_remanente"] = (int)(((decimal)(int)fila["restante_num_cuotas"]) * num_dias_mes);
            fila2["tasa_interes"] = (decimal)fila["interes_corriente"];
            fila2["monto_saldo"] = (decimal)fila["p_saldo"];
            tabla2.Rows.Add(fila2);
            num_row += 1;
        }
        ExportarExcel(tabla2, "FormatoNafibo_" + Fecha.ToString("d").Replace('/', '_'));
    }

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <%--<uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="nafiboEjecutadoProyectado" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Reportes Nafibo - Ejecutado y Proyectado</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_reporte" runat="server" DefaultButton="btn_obtener">
                    <table class="formEntTable">
                        <tr>
                            <td class="formEntTdForm">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun">Tipo de reporte:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_ejecutado" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" OnSelectedIndexChanged="rbl_ejecutado_SelectedIndexChanged">
                                                <asp:ListItem Text="Ejecutado" Value="True" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Proyectado" Value="False"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_fecha" runat="server" Text="Periodo:"></asp:Label></td>
                                        <td class="formTdDato">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td><ew:CalendarPopup ID="cp_inicio" runat="server"></ew:CalendarPopup></td>
                                                    <td><asp:Label ID="lbl_periodo" runat="server" Text="-"></asp:Label></td>
                                                    <td><ew:CalendarPopup ID="cp_fin" runat="server"></ew:CalendarPopup></td>
                                                    <td><asp:LinkButton ID="lb_guardar_ejecutado" runat="server" Text="Guardar ajuste" OnClientClick="return confirm('¿Esta seguro que desea guardar los ajustes de este periodo?')" OnClick="lb_guardar_ejecutado_Click"></asp:LinkButton></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Pagos:</td>
                                        <td class="formTdDato">
                                            <asp:RadioButtonList ID="rbl_solo_pagos" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                                <asp:ListItem Text="Capital Interés" Value="False" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Monto pagado" Value="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Ajuste de Nº cuotas:</td>
                                        <td class="formTdDato">
                                            <asp:CheckBox ID="cb_ajuste" runat="server" Text="Realizar ajuste de Nº cuotas" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:Button ID="btn_obtener" runat="server" Text="Obtener datos" OnClick="btn_obtener_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:TextBox ID="txt_contratos_selectivo" runat="server"></asp:TextBox>
                                <asp:Button ID="btn_obtener_selectivo" runat="server" Text="Obtener datos (selectivo)" OnClick="btn_obtener_selectivo_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formTdMsg">
                                <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br /><br /><br /><br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Formato Nafibo:
                                <asp:TextBox ID="txt_formato_nafibo" runat="server"></asp:TextBox>
                                <ew:CalendarPopup ID="cp_formato_nafibo" runat="server"></ew:CalendarPopup>
                                <asp:Button ID="btn_formato_nafibo" runat="server" Text="Obtener datos en formato nafibo" OnClick="btn_formato_nafibo_Click" />
                            </td>
                        </tr>
                        
                        
                    </table>
                </asp:Panel>            
            </td>
        </tr>
    </table>
</asp:Content>