<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>
<%@ Import Namespace="System.Collections.Generic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    public List<tmpCxCAnio> Cxc_Gestiones(DateTime Fecha, string Id_negocio, int Id_moneda)
    {
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        //[negocio],[id_contrato]
        //[cliente_paterno],[cliente_materno],
        //[numero],[precio_final],[seguro],[mantenimiento_sus],[interes_corriente],   [cuota_base],[fecha_inicio_plan]
        //[urbanizacion],[urbanizacion_corto],[manzano],[lote],[superficie_m2],
        //[realizado_num_cuotas],[realizado_amortizacion],[realizado_seguro],[realizado_mantenimiento],[realizado_interes],[realizado_total],
        //[restante_num_cuotas],[restante_amortizacion],[restante_seguro],[restante_mantenimiento],[restante_interes],[restante_total],
        //[total_num_cuotas],[total_precio],[total_seguro],[total_mantenimiento],[total_interes],[total_total]

        List<tmpCxCAnio> ListaAnios = new List<tmpCxCAnio>();

        //DbCommand cmd = db1.GetStoredProcCommand("contabilidad_Cxc_NegocioUrbanizacion");
        //cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        //db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
        //db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
        //db1.AddInParameter(cmd, "id_moneda", DbType.Int32, Id_moneda);
        //DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];
        //DataTable tabla = contabilidadReporte.Cxc_NegocioUrbanizacion(Fecha, Id_negocio, Id_moneda, true);

        string codigo_moneda = new moneda(Id_moneda).codigo;
        DataTable tabla_sus; DataTable tabla_bs;
        int Id_segunda_moneda = new moneda("Bs").id_moneda;
        tabla_sus = Cxc_NegocioUrbanizacion_original(Fecha, Id_negocio, Id_moneda);
        tabla_bs = Cxc_NegocioUrbanizacion_original(Fecha, Id_negocio, Id_segunda_moneda);

        DataTable tabla = general.ConsolidarReporte(tabla_sus, tabla_bs, codigo_moneda, "tipo_cambio", "precio_final,mantenimiento_sus,cuota_base,realizado_amortizacion,realizado_seguro,realizado_mantenimiento,realizado_interes,realizado_total,restante_amortizacion,restante_seguro,restante_mantenimiento,restante_interes,restante_total,total_precio,total_seguro,total_mantenimiento,total_interes,total_total,p_seguro,p_mantenimiento_sus,p_interes,p_monto_pago,p_amortizacion,p_saldo", false, false, "", "orden_negocio,urbanizacion,numero");

        foreach (DataRow fila in tabla.Rows)
        {
            List<sim_pago> ListaPagos = new List<sim_pago>();

            PagosRestantes((int)fila["id_contrato"], Fecha, ref ListaPagos,
                (decimal)fila["interes_corriente"], (decimal)fila["mantenimiento_sus"], (decimal)fila["seguro"], (decimal)fila["cuota_base"], (DateTime)fila["fecha_inicio_plan"],
                (int)fila["id_ultimo_pago"]
                , (DateTime)fila["p_fecha"], (DateTime)fila["p_fecha_proximo"], (int)fila["p_num_cuotas"], (decimal)fila["p_seguro"], (int)fila["p_seguro_meses"], (DateTime)fila["p_seguro_fecha"]
                , (decimal)fila["p_mantenimiento_sus"], (int)fila["p_mantenimiento_meses"], (DateTime)fila["p_mantenimiento_fecha"], (decimal)fila["p_interes"]
                , (int)fila["p_interes_dias"], (int)fila["p_interes_dias_total"], (DateTime)fila["p_interes_fecha"], (decimal)fila["p_monto_pago"], (decimal)fila["p_amortizacion"], (decimal)fila["p_saldo"]);


            int anio_saldo0 = 0;
            int mes_saldo0 = 0;
            foreach (sim_pago objPS in ListaPagos) { if (objPS.saldo == 0) { anio_saldo0 = objPS.fecha.Year; mes_saldo0 = objPS.fecha.Month; } }
            foreach (sim_pago objPS in ListaPagos)
            {
                tmpCxCAnio.Add(ref ListaAnios, objPS.fecha.Year, objPS.fecha.Month, objPS.amortizacion, objPS.interes, objPS.mantenimiento_sus, anio_saldo0, mes_saldo0);
            }
        }
        return ListaAnios;
    }

    private static DataTable Cxc_NegocioUrbanizacion_original(DateTime Fecha, string Id_negocio, int Id_moneda)
    {
        Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);
        DbCommand cmd = db1.GetStoredProcCommand("contabilidad_Cxc_NegocioUrbanizacion");
        cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
        db1.AddInParameter(cmd, "fecha", DbType.DateTime, Fecha);
        db1.AddInParameter(cmd, "id_negocio", DbType.String, Id_negocio);
        db1.AddInParameter(cmd, "id_moneda", DbType.String, Id_moneda);
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
        return tabla;
    }


    public static void PagosRestantes(int Id_contrato, DateTime Fecha, ref List<sim_pago> ListaPagos,
        decimal pp_interes_corriente, decimal pp_mantenimiento_sus, decimal pp_seguro, decimal pp_cuota_base, DateTime pp_fecha_inicio_plan, int Id_ultimo_pago

        , DateTime p_fecha, DateTime p_fecha_proximo, int p_num_cuotas, decimal p_seguro, int p_seguro_meses, DateTime p_seguro_fecha
        , decimal p_mantenimiento_sus, int p_mantenimiento_meses, DateTime p_mantenimiento_fecha, decimal p_interes
        , int p_interes_dias, int p_interes_dias_total, DateTime p_interes_fecha, decimal p_monto_pago, decimal p_amortizacion, decimal p_saldo)
    {
        //sim_pago pago_simulado = new sim_pago(Id_ultimo_pago);
        sim_pago pago_simulado = new sim_pago(p_fecha, p_fecha_proximo, p_num_cuotas, p_seguro, p_seguro_meses, p_seguro_fecha
            , p_mantenimiento_sus, p_mantenimiento_meses, p_mantenimiento_fecha, p_interes
            , p_interes_dias, p_interes_dias_total, p_interes_fecha, p_monto_pago, p_amortizacion, p_saldo);

        if (pp_cuota_base == 0 && pago_simulado.saldo > 0) pp_cuota_base = pago_simulado.saldo;
        while (pago_simulado.saldo > 0)
        {
            pago_simulado = new sim_pago(pago_simulado, pago_simulado.fecha_proximo, 1,
                pp_cuota_base, pp_fecha_inicio_plan, pp_seguro,
                pp_mantenimiento_sus, pp_interes_corriente);

            ListaPagos.Add(pago_simulado);
        }
    }

    public class tmpCxCAnio
    {
        #region Propiedades
        //Propiedades privadas
        private int _anio = 0;
        private int _mes = 0;
        private string _mes_string = "";
        private decimal _saldo0_num_contratos = 0;
        private decimal _saldo0_capital = 0;
        private decimal _saldo0_interes = 0;
        private decimal _saldo0_mantenimiento = 0;

        private decimal _parcial_num_contratos = 0;
        private decimal _parcial_capital = 0;
        private decimal _parcial_interes = 0;
        private decimal _parcial_mantenimiento = 0;

        //Propiedades públicas
        public int anio { get { return _anio; } set { _anio = value; } }
        public int mes { get { return _mes; } set { _mes = value; } }
        public string mes_string { get { return _mes_string; } set { _mes_string = value; } }

        public decimal saldo0_num_contratos { get { return _saldo0_num_contratos; } set { _saldo0_num_contratos = value; } }
        public decimal saldo0_capital { get { return _saldo0_capital; } set { _saldo0_capital = value; } }
        public decimal saldo0_interes { get { return _saldo0_interes; } set { _saldo0_interes = value; } }
        public decimal saldo0_mantenimiento { get { return _saldo0_mantenimiento; } set { _saldo0_mantenimiento = value; } }

        public decimal parcial_num_contratos { get { return _parcial_num_contratos; } set { _parcial_num_contratos = value; } }
        public decimal parcial_capital { get { return _parcial_capital; } set { _parcial_capital = value; } }
        public decimal parcial_interes { get { return _parcial_interes; } set { _parcial_interes = value; } }
        public decimal parcial_mantenimiento { get { return _parcial_mantenimiento; } set { _parcial_mantenimiento = value; } }
  
        #endregion

        #region Constructores
        public tmpCxCAnio(int Anio_pago, int Mes_pago, decimal Capital, decimal Interes, decimal Mantenimiento, int Anio_saldo0, int Mes_saldo0)
        {
            _anio = Anio_pago;
            _mes = Mes_pago;
            switch (_mes)
            {
                case 1: _mes_string = "Enero"; break;
                case 2: _mes_string = "Febrero"; break;
                case 3: _mes_string = "Marzo"; break;
                case 4: _mes_string = "Abril"; break;
                case 5: _mes_string = "Mayo"; break;
                case 6: _mes_string = "Junio"; break;
                case 7: _mes_string = "Julio"; break;
                case 8: _mes_string = "Agosto"; break;
                case 9: _mes_string = "Sptiembre"; break;
                case 10: _mes_string = "Octubre"; break;
                case 11: _mes_string = "Noviembre"; break;
                case 12: _mes_string = "Diciembre"; break;
            }
            
            if (Anio_pago == Anio_saldo0 && Mes_pago == Mes_saldo0)
            {
                _saldo0_num_contratos = 1;
                _saldo0_capital = Capital;
                _saldo0_interes = Interes;
                _saldo0_mantenimiento = Mantenimiento;

                _parcial_num_contratos = 0;
                _parcial_capital = 0;
                _parcial_interes = 0;
                _parcial_mantenimiento = 0;
            }
            else
            {
                _saldo0_num_contratos = 0;
                _saldo0_capital = 0;
                _saldo0_interes = 0;
                _saldo0_mantenimiento = 0;

                _parcial_num_contratos = 1;
                _parcial_capital = Capital;
                _parcial_interes = Interes;
                _parcial_mantenimiento = Mantenimiento;
            }
        }
        #endregion

        public static void Add(ref List<tmpCxCAnio> lista, int Anio_pago, int Mes_pago, decimal Capital, decimal Interes, decimal Mantenimiento, int Anio_saldo, int Mes_saldo)
        {
            tmpCxCAnio item = new tmpCxCAnio(Anio_pago, Mes_pago, Capital, Interes, Mantenimiento, Anio_saldo, Mes_saldo);

            bool existe = false;
            foreach (tmpCxCAnio item_lista in lista)
            {
                if (item_lista.anio == item.anio && item_lista.mes == item.mes)
                {
                    existe = true;
                    item_lista.saldo0_num_contratos += item.saldo0_num_contratos;
                    item_lista.saldo0_capital += item.saldo0_capital;
                    item_lista.saldo0_interes += item.saldo0_interes;
                    item_lista.saldo0_mantenimiento += item.saldo0_mantenimiento;

                    item_lista.parcial_num_contratos += item.parcial_num_contratos;
                    item_lista.parcial_capital += item.parcial_capital;
                    item_lista.parcial_interes += item.parcial_interes;
                    item_lista.parcial_mantenimiento += item.parcial_mantenimiento;
                }
            }

            if (existe == false) { lista.Add(item); }
        }
    }

    protected void btn_mostrar_reporte_Click(object sender, EventArgs e)
    {
        moneda mObj = new moneda("$us");
        gv.DataSource = Cxc_Gestiones(cp_fecha.SelectedDate, general.StringNegocios(true, cbl_negocio.Items), mObj.id_moneda);
        gv.DataBind();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="priTable">
        <tr><td class="priTdTitle">Reporte de Cuentas por Cobrar (detalle)</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_mostrar_reporte">
                    <table class="formEntTable">
                        <tr>
                            <td class="formEntTdForm">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun">A la fecha:</td>
                                        <td class="formTdDato"><ew:CalendarPopup ID="cp_fecha" runat="server" Width="100px"></ew:CalendarPopup></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Negocio:</td>
                                        <td class="formTdDato">
                                            <asp:CheckBoxList ID="cbl_negocio" runat="server" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2"></asp:CheckBoxList>
                                            <%--[id_negocio],[codigo],[nombre],[origen]--%>
                                            <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:Button ID="btn_mostrar_reporte" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true" OnClick="btn_mostrar_reporte_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gv" runat="server"></asp:GridView>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
