<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Reporte de cartera vigente para promociones" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Text" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteCarteraVigente2") == true)
            {
                //bool permiso_cartera_vigente_con_retraso = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContabilidad", "reporteCarteraVigente2_retraso");
/*
                bool permiso_cartera_vigente_con_retraso = false;
                if (Profile.entorno.codigo_modulo == "adm" || Profile.id_usuario == 411 || Profile.id_usuario == 353 || Profile.id_usuario == 445) { permiso_cartera_vigente_con_retraso = true; }
                lbl_retraso.Visible = permiso_cartera_vigente_con_retraso;
                cb_retraso.Visible = permiso_cartera_vigente_con_retraso;
                cb_retraso.Checked = false;
*/
				cb_retraso.Visible = true;
				cb_retraso.Checked = false;
			}
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    protected void btn_mostrar_Click(object sender, EventArgs e)
    {
        cargarReporte();
    }

    public void cargarReporte()
    {
        string Codigo_moneda = new moneda(int.Parse(rbl_moneda.SelectedValue)).codigo;
        if (cb_retraso.Checked == false)
        {
            rpt_cartera_vigente2 reporte = new rpt_cartera_vigente2();
            reporte.DataSource = contabilidadReporte.CarteraVigente2(cp_fecha.SelectedDate, general.StringNegocios(true, cbl_negocio.Items), int.Parse(ddl_localizacion.SelectedValue), int.Parse(ddl_urbanizacion.SelectedValue), int.Parse(ddl_manzano.SelectedValue), decimal.Parse(txt_saldo_menor.Text.Trim()), decimal.Parse(txt_saldo_mayor.Text.Trim()), ddl_orden.SelectedValue, int.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"));
            reporte.CargarDatos(cp_fecha.SelectedDate, general.StringNegocios(false, cbl_negocio.Items), ddl_localizacion.SelectedItem.Text, ddl_urbanizacion.SelectedItem.Text, ddl_manzano.SelectedItem.Text, decimal.Parse(txt_saldo_menor.Text.Trim()), decimal.Parse(txt_saldo_mayor.Text.Trim()), rbl_moneda.SelectedItem.Text.ToUpper(), rbl_consolidado.SelectedItem.Text.ToUpper(), Codigo_moneda);
            Reporte1.WebView.Report = reporte;
        }
        else
        {
            DataTable tabla_datos = contabilidadReporte.CarteraVigente2(cp_fecha.SelectedDate, general.StringNegocios(true, cbl_negocio.Items), int.Parse(ddl_localizacion.SelectedValue), int.Parse(ddl_urbanizacion.SelectedValue), int.Parse(ddl_manzano.SelectedValue), decimal.Parse(txt_saldo_menor.Text.Trim()), decimal.Parse(txt_saldo_mayor.Text.Trim()), ddl_orden.SelectedValue, int.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"));
            DataTable datos = DatosDeRetraso(tabla_datos);

            rpt_cartera_vigente2Retraso reporte = new rpt_cartera_vigente2Retraso();
            reporte.DataSource = datos;
            reporte.CargarDatos(cp_fecha.SelectedDate, general.StringNegocios(false, cbl_negocio.Items), ddl_localizacion.SelectedItem.Text, ddl_urbanizacion.SelectedItem.Text, ddl_manzano.SelectedItem.Text, decimal.Parse(txt_saldo_menor.Text.Trim()), decimal.Parse(txt_saldo_mayor.Text.Trim()), rbl_moneda.SelectedItem.Text.ToUpper(), rbl_consolidado.SelectedItem.Text.ToUpper(), Codigo_moneda);
            Reporte1.WebView.Report = reporte;
        }
    }

    protected void ddl_DataBound(object sender, EventArgs e)
    {
        ((DropDownList)sender).Items.Insert(0, new ListItem("Todos", "0"));
    }

    protected void cbl_negocio_DataBound(object sender, EventArgs e)
    {
        string casas_edif = ConfigurationManager.AppSettings["negocios_casas"];
        foreach (ListItem item in cbl_negocio.Items)
        {
            item.Selected = casas_edif.Contains("|" + item.Text + "|").Equals(false);
        }
    }

    protected void rbl_moneda_DataBound(object sender, EventArgs e)
    {
        if (rbl_moneda.Items.Count > 0)
        {
            rbl_moneda.SelectedIndex = 0;
        }
    }

    protected void rbl_consolidado_DataBound(object sender, EventArgs e)
    {
        if (rbl_consolidado.Items.Count > 0)
        {
            rbl_consolidado.SelectedIndex = 0;
        }
        lbl_consolidado_enun.Text = "Datos contemplados:";
    }

    protected DataTable DatosDeRetraso(DataTable tabla)
    {
        //[negocio],[numero_contrato],[fecha_registro],[localizacion],[urbanizacion],[manzano],[lote],[nombre_cliente],[celular],[email],[domicilio_fono],[oficina_fono]
        //[interes_corriente],[num_cuotas],[fecha_ultimo_pago],[interes_fecha],[fecha_proximo],[num_dias_retraso],[num_cuotas_adeuda],[num_dias_mora],[num_cuotas_mora],[porcentaje_saldo],[codigo_moneda]
        //[tipo_cambio],[cuota_base],[precio_final],[total_amortizacion],[saldo]
        //Orden:[numero_contrato]

        tabla.Columns.Add("rango", typeof(string));
        foreach (DataRow fila in tabla.Rows)
        {
            int especial = (int)fila["especial"];
            int num_dias_retraso = (int)fila["num_dias_retraso"];

            if (especial == 1) fila["rango"] = "Contratos de cartera especial";
            else if (num_dias_retraso == 0) fila["rango"] = "Contratos al día";
            else if (num_dias_retraso >= 1 && num_dias_retraso <= 30) fila["rango"] = "Contratos con retraso de 1 a 30 días";
            else if (num_dias_retraso >= 31 && num_dias_retraso <= 60) fila["rango"] = "Contratos con retraso de 31 a 60 días";
            else if (num_dias_retraso >= 61 && num_dias_retraso <= 90) fila["rango"] = "Contratos con retraso de 61 a 90 días";
            else if (num_dias_retraso >= 91 && num_dias_retraso <= 120) fila["rango"] = "Contratos con retraso de 91 a 120 días";
            else fila["rango"] = "Contratos con retraso mayor 120 días";
        }
        //for (int j = tabla.Rows.Count - 1; j >= 0; j--) { if ((int)tabla.Rows[j]["num_dias_retraso"] == 0) { tabla.Rows.RemoveAt(j); } }

        tabla.DefaultView.Sort = "especial,num_dias_retraso";
        return tabla.DefaultView.ToTable();
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteContabilidad" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte de cartera vigente para promociones</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdButtonVolver">
                    </td>
                </tr>
                <tr>
                    <td class="tdFiltro">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_fecha" runat="server" Text="A la fecha:"></asp:Label></td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="cp_fecha" runat="server" AutoPostBack="false">
                                    </ew:CalendarPopup>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Localización:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataSourceID="ods_localizacion_lista" DataTextField="nombre" DataValueField="id_localizacion" OnDataBound="ddl_DataBound"></asp:DropDownList>
                                    <%--[id_localizacion],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_localizacion_lista" runat="server" TypeName="terrasur.localizacion" SelectMethod="Lista"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Sector:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataSourceID="ods_urb_lista" DataTextField="nombre_completo" DataValueField="id_urbanizacion" OnDataBound="ddl_DataBound"></asp:DropDownList>
                                    <%--[id_urbanizacion],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_urb_lista" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Manzano:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_manzano" runat="server" DataSourceID="ods_manzano_lista" DataTextField="codigo" DataValueField="id_manzano" OnDataBound="ddl_DataBound"></asp:DropDownList>
                                    <%--[id_manzano],[codigo]--%>
                                    <asp:ObjectDataSource ID="ods_manzano_lista" runat="server" TypeName="terrasur.manzano" SelectMethod="Lista">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Negocio:</td>
                                <td class="formTdDato">
                                    <asp:CheckBoxList ID="cbl_negocio" runat="server" DataSourceID="ods_lista_negocio" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2" OnDataBound="cbl_negocio_DataBound"></asp:CheckBoxList>
                                    <asp:ObjectDataSource ID="ods_lista_negocio" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">% Saldo restante:</td>
                                <td class="formTdDato">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txt_saldo_menor" runat="server" Text="0" SkinID="txtSingleLine50" MaxLength="5" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_saldo_menor" runat="server" ControlToValidate="txt_saldo_menor" Display="Dynamic" ValidationGroup="filtro" Text="*" ErrorMessage="Debe introducir el porcentaje de saldo restante"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="cv_saldo_menor" runat="server" ControlToValidate="txt_saldo_menor" Display="Dynamic" ValidationGroup="filtro" Text="*"  ErrorMessage="El porcentaje de saldo debe ser un número válido" Type="Double" Operator="DataTypeCheck"></asp:CompareValidator>
                                            </td>
                                            <td>% - </td>
                                            <td>
                                                <asp:TextBox ID="txt_saldo_mayor" runat="server" Text="100" SkinID="txtSingleLine50" MaxLength="5" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfv_saldo_mayor" runat="server" ControlToValidate="txt_saldo_mayor" Display="Dynamic" ValidationGroup="filtro" Text="*" ErrorMessage="Debe introducir el porcentaje de saldo restante"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="cv_saldo_mayor" runat="server" ControlToValidate="txt_saldo_mayor" Display="Dynamic" ValidationGroup="filtro" Text="*"  ErrorMessage="El porcentaje de saldo debe ser un número válido" Type="Double" Operator="DataTypeCheck"></asp:CompareValidator>
                                                <asp:CompareValidator ID="cv_saldo_restante" runat="server" ControlToValidate="txt_saldo_mayor" ControlToCompare="txt_saldo_menor" Display="Dynamic" ValidationGroup="filtro" Text="*"  ErrorMessage="El rango del porcentaje de saldo es incorrecto" Type="Double" Operator="GreaterThanEqual"></asp:CompareValidator>
                                            </td>
                                            <td>%</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Moneda:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_moneda" runat="server" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnDataBound="rbl_moneda_DataBound">
                                    </asp:RadioButtonList>
                                    <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
                                    <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_consolidado_enun" runat="server"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_consolidado" runat="server" DataSourceID="ods_lista_consolidado" DataValueField="valor" DataTextField="texto" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnDataBound="rbl_consolidado_DataBound">
                                    </asp:RadioButtonList>
                                    <%--[valor],[texto]--%>
                                    <asp:ObjectDataSource ID="ods_lista_consolidado" runat="server" TypeName="terrasur.general" SelectMethod="ListaOpcionesConsolidado">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Ordenar por:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_orden" runat="server">
                                        <asp:ListItem Text="Sector" Value="localizacion,urbanizacion,porcentaje_saldo"></asp:ListItem>
                                        <asp:ListItem Text="% Saldo" Value="porcentaje_saldo"></asp:ListItem>
                                        <asp:ListItem Text="Días de retraso" Value="num_dias_retraso"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_retraso" runat="server" Text="Contratos retrasados:"></asp:Label></td>
                                <td class="formTdDato"><asp:CheckBox ID="cb_retraso" runat="server" Text="Mostrar solo contratos retrasados" /></td>
                            </tr>
                            <tr>
                                <td class="formTdMsg" colspan="2">
                                    <asp:ValidationSummary ID="vs_filtro" runat="server" DisplayMode="List" ValidationGroup="filtro" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton" colspan="2">
                                   <asp:Button ID="btn_mostrar" runat="server" SkinID="btnAccion" Text="Mostrar reporte" CausesValidation="true" ValidationGroup="filtro" OnClick="btn_mostrar_Click" />
                                </td>
                            </tr>
                         </table>
                    </td>
                </tr>
                <tr>
                    <td class="tdGrid">
                    <uc1:reporte ID="Reporte1" runat="server" NombreReporte="CarteraVigente" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>
