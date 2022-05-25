<%@ Page Language="C#" Title="Reporte de intercambio de información con Síntesis" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<%@ Import Namespace="System.Data" %> 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["tipo_reporte"] != null)
        {
            string tipo_reporte = Session["tipo_reporte"].ToString();
            Session.Remove("tipo_reporte");
            DateTime fecha = (DateTime)Session["fecha"];

            int id_eeff = (int)Session["id_eeff"];
            int id_sucursal_eeff = (int)Session["id_sucursal_eeff"];
            int id_pagopendiente = (int)Session["id_pagopendiente"];
            
            string string_eeff = Session["string_eeff"].ToString();
            string string_sucursal_eeff = Session["string_sucursal_eeff"].ToString();
            string string_usuario = Session["string_usuario"].ToString();
            string string_fechas = Session["string_fechas"].ToString();
            string num_contrato = Session["num_contrato"].ToString();
            string string_id_pagopendiente = Session["string_id_pagopendiente"].ToString();

            if (tipo_reporte == "resumen")
            {
                string tipo_solicitud = ""; string string_tipo_solicitud = "";
                if (Session["tipo_solicitud"] != null) { tipo_solicitud = Session["tipo_solicitud"].ToString(); }
                if (Session["string_tipo_solicitud"] != null) { string_tipo_solicitud = Session["string_tipo_solicitud"].ToString(); }
                DateTime fecha_inicio = DateTime.Now; DateTime fecha_fin = DateTime.Now;
                if (Session["fecha_inicio"] != null) { fecha_inicio = (DateTime)Session["fecha_inicio"]; }
                if (Session["fecha_fin"] != null) { fecha_fin = (DateTime)Session["fecha_fin"]; }

                rpt_sintesis_resumen reporte_resumen = new rpt_sintesis_resumen();
                DataTable tabla_resumen = terrasur.sintesis.s_reporte.reporte_resumen(id_eeff, id_sucursal_eeff,
                    string_usuario, fecha_inicio, fecha_fin, num_contrato, id_pagopendiente, tipo_solicitud);
                reporte_resumen.DataSource = tabla_resumen;
                reporte_resumen.Encabezado(string_eeff, string_sucursal_eeff, string_usuario, string_fechas, num_contrato, string_id_pagopendiente, string_tipo_solicitud, Profile.nombre_persona, tabla_resumen.Rows.Count);
                Reporte1.WebView.Report = reporte_resumen;
            }
            else
            {
                DataTable tabla = terrasur.sintesis.s_reporte.reporte_control(tipo_reporte, id_eeff, id_sucursal_eeff, string_usuario,
                    fecha, fecha, num_contrato, id_pagopendiente);

                switch (tipo_reporte)
                {
                    case "busqueda_cliente":
                        rpt_sintesis_busqueda_cliente reporte_01 = new rpt_sintesis_busqueda_cliente();
                        reporte_01.DataSource = tabla;
                        reporte_01.Encabezado(string_eeff, string_sucursal_eeff, string_usuario, string_fechas, num_contrato, string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
                        Reporte1.WebView.Report = reporte_01;
                        break;
                    case "solicitud_tipo_pago":
                        rpt_sintesis_tipo_pago reporte_02 = new rpt_sintesis_tipo_pago();
                        reporte_02.DataSource = tabla;
                        reporte_02.Encabezado(string_eeff, string_sucursal_eeff, string_usuario, string_fechas, num_contrato, string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
                        Reporte1.WebView.Report = reporte_02;
                        break;
                    case "solicitud_contrato":
                        rpt_sintesis_contrato reporte_03 = new rpt_sintesis_contrato();
                        reporte_03.DataSource = tabla;
                        reporte_03.Encabezado(string_eeff, string_sucursal_eeff, string_usuario, string_fechas, num_contrato, string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
                        Reporte1.WebView.Report = reporte_03;
                        break;
                    case "solicitud_pago":
                        rpt_sintesis_pago reporte_04 = new rpt_sintesis_pago();
                        reporte_04.DataSource = tabla;
                        reporte_04.Encabezado(string_eeff, string_sucursal_eeff, string_usuario, string_fechas, num_contrato, string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
                        Reporte1.WebView.Report = reporte_04;
                        break;
                    case "conciliacion":
                        rpt_sintesis_conciliacion reporte_05 = new rpt_sintesis_conciliacion();
                        reporte_05.DataSource = tabla;
                        reporte_05.Encabezado(string_eeff, string_sucursal_eeff, string_usuario, string_fechas, num_contrato, string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
                        Reporte1.WebView.Report = reporte_05;
                        break;
                    case "verificacion_anulacion":
                        rpt_sintesis_verificacion_anulacion reporte_06 = new rpt_sintesis_verificacion_anulacion();
                        reporte_06.DataSource = tabla;
                        reporte_06.Encabezado(string_eeff, string_sucursal_eeff, string_usuario, string_fechas, num_contrato, string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
                        Reporte1.WebView.Report = reporte_06;
                        break;
                    case "anulacion":
                        rpt_sintesis_anulacion reporte_07 = new rpt_sintesis_anulacion();
                        reporte_07.DataSource = tabla;
                        reporte_07.Encabezado(string_eeff, string_sucursal_eeff, string_usuario, string_fechas, num_contrato, string_id_pagopendiente, Profile.nombre_persona, tabla.Rows.Count);
                        Reporte1.WebView.Report = reporte_07;
                        break;
                }

            }
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <uc2:reporte ID="Reporte1" runat="server" NombreReporte="ReporteSintesis" />
    </div>
    </form>
</body>
</html>
