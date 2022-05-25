<%@ Control Language="C#" ClassName="contratoReembolsoAbm" %>
<%@ Import Namespace="System.Data" %>
<script runat="server">
    public void CargarInsertar(int Id_contrato, DateTime Fecha)
    {
        //num_contrato,estado,estado_string,producto,fecha_venta,fecha_ultimo_pago,fecha_interes,fecha_reversion
        //precio_final,capital_pagado,interes_pagado,total_pagado,saldo,cuotas_pagadas
        DataTable tabla_datos_contrato = terrasur.traspaso.reembolso.ListaDatosContrato(Id_contrato, Fecha);

        lbl_num_contrato.Text = tabla_datos_contrato.Rows[0]["num_contrato"].ToString();
        lb_estado.Text = tabla_datos_contrato.Rows[0]["estado_string"].ToString();
        lbl_producto.Text = tabla_datos_contrato.Rows[0]["producto"].ToString();
        if ((DateTime)tabla_datos_contrato.Rows[0]["fecha_venta"] != DateTime.Parse("01/01/1900")) { lbl_fecha_venta.Text = ((DateTime)tabla_datos_contrato.Rows[0]["fecha_venta"]).ToString("d"); } else { lbl_fecha_venta.Text = "---"; }
        if ((DateTime)tabla_datos_contrato.Rows[0]["fecha_ultimo_pago"] != DateTime.Parse("01/01/1900")) { lbl_fecha_ultimo_pago.Text = ((DateTime)tabla_datos_contrato.Rows[0]["fecha_ultimo_pago"]).ToString("d"); } else { lbl_fecha_ultimo_pago.Text = "---"; }
        if ((DateTime)tabla_datos_contrato.Rows[0]["fecha_interes"] != DateTime.Parse("01/01/1900")) { lbl_fecha_interes.Text = ((DateTime)tabla_datos_contrato.Rows[0]["fecha_interes"]).ToString("d"); } else { lbl_fecha_interes.Text = "---"; }
        if ((DateTime)tabla_datos_contrato.Rows[0]["fecha_reversion"] != DateTime.Parse("01/01/1900")) { lbl_fecha_reversion.Text = ((DateTime)tabla_datos_contrato.Rows[0]["fecha_reversion"]).ToString("d"); } else { lbl_fecha_reversion.Text = "---"; }

        //[id_cliente],[nombre],[ci],[primer_titular]
        //gv_cliente_contrato.DataSource = terrasur.traspaso.cliente_reembolso.ListaPorContrato(Id_contrato);
        //gv_cliente_contrato.DataBind();
        //lbl_cliente.Text = terrasur.traspaso.cliente_reembolso.ListaPorContrato_string(Id_contrato, false).Replace(",", "</br>");
        lbl_cliente.Text = terrasur.traspaso.cliente_reembolso.ListaPorContrato_string(Id_contrato, false);
       
        string codigo_moneda = contrato.CodigoMoneda(Id_contrato);
        
        lbl_precio_final_enun.Text = "Precio" + " " + codigo_moneda + ":";
        lbl_capital_pagado_enun.Text = "Capital Pag." + " " + codigo_moneda + ":";
        lbl_interes_pagado_enun.Text = "Interés Pag." + " " + codigo_moneda + ":";
        lbl_total_pagado_enun.Text = "Monto Pag." + " " + codigo_moneda + ":";
        lbl_saldo_enun.Text = "Saldo" + " " + codigo_moneda + ":";

        lbl_precio_final.Text = ((decimal)tabla_datos_contrato.Rows[0]["precio_final"]).ToString("N2");
        lbl_capital_pagado.Text = ((decimal)tabla_datos_contrato.Rows[0]["capital_pagado"]).ToString("N2");
        lbl_interes_pagado.Text = ((decimal)tabla_datos_contrato.Rows[0]["interes_pagado"]).ToString("N2");
        lbl_total_pagado.Text = ((decimal)tabla_datos_contrato.Rows[0]["total_pagado"]).ToString("N2");
        lbl_saldo.Text = ((decimal)tabla_datos_contrato.Rows[0]["saldo"]).ToString("N2");
        lbl_cuotas_pagadas.Text= tabla_datos_contrato.Rows[0]["cuotas_pagadas"].ToString();
        lbl_interes_corriente.Text = ((decimal)tabla_datos_contrato.Rows[0]["interes_corriente"]).ToString("N2");
                
        //gv_datos_contrato.DataSource = tabla_datos_contrato;
        //gv_datos_contrato.DataBind();
    }

    public void CargarActualizar(int Id_reembolso)
    {
        //num_contrato,estado,estado_string,producto,fecha_venta,fecha_ultimo_pago,fecha_interes,fecha_reversion
        //precio_final,capital_pagado,interes_pagado,total_pagado,saldo,cuotas_pagadas
        DataTable tabla_datos_contrato = terrasur.traspaso.reembolso.ListaDatosReembolso(Id_reembolso);

        lbl_num_contrato.Text = tabla_datos_contrato.Rows[0]["num_contrato"].ToString();
        lb_estado.Text = tabla_datos_contrato.Rows[0]["estado_string"].ToString();
        lbl_producto.Text = tabla_datos_contrato.Rows[0]["producto"].ToString();
        if ((DateTime)tabla_datos_contrato.Rows[0]["fecha_venta"] != DateTime.Parse("01/01/1900")) { lbl_fecha_venta.Text = ((DateTime)tabla_datos_contrato.Rows[0]["fecha_venta"]).ToString("d"); } else { lbl_fecha_venta.Text = ""; }
        if ((DateTime)tabla_datos_contrato.Rows[0]["fecha_ultimo_pago"] != DateTime.Parse("01/01/1900")) { lbl_fecha_ultimo_pago.Text = ((DateTime)tabla_datos_contrato.Rows[0]["fecha_ultimo_pago"]).ToString("d"); } else { lbl_fecha_ultimo_pago.Text = ""; }
        if ((DateTime)tabla_datos_contrato.Rows[0]["fecha_interes"] != DateTime.Parse("01/01/1900")) { lbl_fecha_interes.Text = ((DateTime)tabla_datos_contrato.Rows[0]["fecha_interes"]).ToString("d"); } else { lbl_fecha_interes.Text = ""; }
        if ((DateTime)tabla_datos_contrato.Rows[0]["fecha_reversion"] != DateTime.Parse("01/01/1900")) { lbl_fecha_reversion.Text = ((DateTime)tabla_datos_contrato.Rows[0]["fecha_reversion"]).ToString("d"); } else { lbl_fecha_reversion.Text = ""; }

        //[id_cliente],[nombre],[ci],[primer_titular]
        //gv_cliente_contrato.DataSource = terrasur.traspaso.cliente_reembolso.Lista(Id_reembolso);
        //gv_cliente_contrato.DataBind();
        //lbl_cliente.Text = terrasur.traspaso.cliente_reembolso.Lista_string(Id_reembolso, false).Replace(",", "</br>");
        lbl_cliente.Text = terrasur.traspaso.cliente_reembolso.Lista_string(Id_reembolso, false);
        
        string codigo_moneda = tabla_datos_contrato.Rows[0]["codigo_moneda"].ToString();
        
        lbl_precio_final_enun.Text = "Precio" + " " + codigo_moneda + ":";
        lbl_capital_pagado_enun.Text = "Capital Pag." + " " + codigo_moneda + ":";
        lbl_interes_pagado_enun.Text = "Interés Pag." + " " + codigo_moneda + ":";
        lbl_total_pagado_enun.Text = "Monto Pag." + " " + codigo_moneda + ":";
        lbl_saldo_enun.Text = "Saldo" + " " + codigo_moneda + ":";

        lbl_precio_final.Text = ((decimal)tabla_datos_contrato.Rows[0]["precio_final"]).ToString("N2");
        lbl_capital_pagado.Text = ((decimal)tabla_datos_contrato.Rows[0]["capital_pagado"]).ToString("N2");
        lbl_interes_pagado.Text = ((decimal)tabla_datos_contrato.Rows[0]["interes_pagado"]).ToString("N2");
        lbl_total_pagado.Text = ((decimal)tabla_datos_contrato.Rows[0]["total_pagado"]).ToString("N2");
        lbl_saldo.Text = ((decimal)tabla_datos_contrato.Rows[0]["saldo"]).ToString("N2");
        lbl_cuotas_pagadas.Text = tabla_datos_contrato.Rows[0]["cuotas_pagadas"].ToString();
        lbl_interes_corriente.Text = ((decimal)tabla_datos_contrato.Rows[0]["interes_corriente"]).ToString("N2");
        
        //gv_datos_contrato.DataSource = tabla_datos_contrato;
        //gv_datos_contrato.DataBind();
    }
    
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table align="center">
    <tr>
        <td align="left" style="padding-left:3px;"><asp:Label ID="lbl_num_contrato_enun" runat="server" Text="Nº contrato:" SkinID="lblEnun"></asp:Label></td>
        <td align="left" style="padding-right:3px;"><asp:Label ID="lbl_num_contrato" runat="server" SkinID="lblDato"></asp:Label></td>
        <td align="left" style="padding-left:3px;"><asp:Label ID="lb_estado_enun" runat="server" Text="Estado:" SkinID="lblEnun"></asp:Label></td>
        <td align="left" style="padding-right:3px;"><asp:Label ID="lb_estado" runat="server" SkinID="lblDato"></asp:Label></td>
        <td align="left" style="padding-left:3px;"><asp:Label ID="lbl_producto_enun" runat="server" Text="Producto:" SkinID="lblEnun"></asp:Label></td>
        <td align="left" style="padding-right:3px;" colspan="3"><asp:Label ID="lbl_producto" runat="server" SkinID="lblDato"></asp:Label></td>
    </tr>
    <tr>
        <td align="left" style="padding-left:3px;"><asp:Label ID="lbl_fecha_venta_enun" runat="server" Text="F.Venta:" SkinID="lblEnun"></asp:Label></td>
        <td align="left" style="padding-right:3px;"><asp:Label ID="lbl_fecha_venta" runat="server" SkinID="lblDato"></asp:Label></td>
        <td align="left" style="padding-left:3px;"><asp:Label ID="lbl_fecha_ultimo_pago_enun" runat="server" Text="F.Últ.Pago:" SkinID="lblEnun"></asp:Label></td>
        <td align="left" style="padding-right:3px;"><asp:Label ID="lbl_fecha_ultimo_pago" runat="server" SkinID="lblDato"></asp:Label></td>
        <td align="left" style="padding-left:3px;"><asp:Label ID="lbl_fecha_interes_enun" runat="server" Text="F.Interés:" SkinID="lblEnun"></asp:Label></td>
        <td align="left" style="padding-right:3px;"><asp:Label ID="lbl_fecha_interes" runat="server" SkinID="lblDato"></asp:Label></td>
        <td align="left" style="padding-left:3px;"><asp:Label ID="lbl_fecha_reversion_enun" runat="server" Text="F.Reversión:" SkinID="lblEnun"></asp:Label></td>
        <td align="left" style="padding-right:3px;"><asp:Label ID="lbl_fecha_reversion" runat="server" SkinID="lblDato"></asp:Label></td>
    </tr>
    <tr>
        <td align="left" style="padding-left:3px;"><asp:Label ID="lbl_precio_final_enun" runat="server" Text="Precio final:" SkinID="lblEnun"></asp:Label></td>
        <td align="left" style="padding-right:3px;"><asp:Label ID="lbl_precio_final" runat="server" SkinID="lblDato"></asp:Label></td>
        <td align="left" style="padding-left:3px;"><asp:Label ID="lbl_capital_pagado_enun" runat="server" Text="Capital Pag.:" SkinID="lblEnun"></asp:Label></td>
        <td align="left" style="padding-right:3px;"><asp:Label ID="lbl_capital_pagado" runat="server" SkinID="lblDato"></asp:Label></td>
        <td align="left" style="padding-left:3px;"><asp:Label ID="lbl_interes_pagado_enun" runat="server" Text="Interés Pag.:" SkinID="lblEnun"></asp:Label></td>
        <td align="left" style="padding-right:3px;"><asp:Label ID="lbl_interes_pagado" runat="server" SkinID="lblDato"></asp:Label></td>
        <td align="left" style="padding-left:3px;"><asp:Label ID="lbl_total_pagado_enun" runat="server" Text="Monto Pag.:" SkinID="lblEnun"></asp:Label></td>
        <td align="left" style="padding-right:3px;"><asp:Label ID="lbl_total_pagado" runat="server" SkinID="lblDato"></asp:Label></td>
    </tr>
    <tr>
        <td align="left" style="padding-left:3px;"><asp:Label ID="lbl_saldo_enun" runat="server" Text="Saldo:" SkinID="lblEnun"></asp:Label></td>
        <td align="left" style="padding-right:3px;"><asp:Label ID="lbl_saldo" runat="server" SkinID="lblDato"></asp:Label></td>
        <td align="left" style="padding-left:3px;"><asp:Label ID="lbl_cuotas_pagadas_enun" runat="server" Text="Nº Cuotas Pag.:" SkinID="lblEnun"></asp:Label></td>
        <td align="left" style="padding-right:3px;"><asp:Label ID="lbl_cuotas_pagadas" runat="server" SkinID="lblDato"></asp:Label></td>
        <td align="left" style="padding-left:3px;"><asp:Label ID="lbl_interes_corriente_enun" runat="server" Text="% interés:" SkinID="lblEnun"></asp:Label></td>
        <td align="left" style="padding-right:3px;"><asp:Label ID="lbl_interes_corriente" runat="server" SkinID="lblDato"></asp:Label></td>
    </tr>
    <tr>
        <td align="left" valign="top" style="padding-left:3px;"><asp:Label ID="lbl_cliente_enun" runat="server" Text="Cliente(s):" SkinID="lblEnun"></asp:Label></td>
        <td align="left" valign="top" colspan="7">
            <table cellpadding="0" cellspacing="0" width="600px"><tr><td><asp:Label ID="lbl_cliente" runat="server"></asp:Label></td></tr></table>
            <%--[id_cliente],[nombre],[ci],[primer_titular]--%>
            <%--<asp:GridView ID="gv_cliente_contrato" runat="server" AutoGenerateColumns="false" ShowHeader="false">
                <Columns>
                    <asp:BoundField HeaderText="Cliente" DataField="nombre" />
                    <asp:BoundField HeaderText="CI" DataField="ci" />
                    <asp:BoundField HeaderText="Titular" DataField="primer_titular" />
                </Columns>
            </asp:GridView>--%>
        </td>
    </tr>
</table>
