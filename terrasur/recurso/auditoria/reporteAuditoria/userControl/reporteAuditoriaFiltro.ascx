<%@ Control Language="C#" ClassName="reporteAuditoriaFiltro" %>

<script runat="server">
    public string Reporte
    {
        get { return lbl_reporte.Text; }
        set
        {
            lbl_reporte.Text = value;
            xml_reporte_audit rep = new xml_reporte_audit(value);
            ReporteNombre = rep.nombre;
            num_contratoVisible = rep.contrato;
            enteroVisible = rep.entero.Equals("").Equals(false);
            if (enteroVisible) lbl_entero_enun.Text = rep.entero.TrimEnd(':') + ":";
            cadenaVisible = rep.cadena.Equals("").Equals(false);
            if (cadenaVisible) lbl_cadena_enun.Text = rep.cadena.TrimEnd(':') + ":";
        }
    }
    public string ReporteNombre { get { return lbl_reporte_nombre.Text; } set { lbl_reporte_nombre.Text = value; } }
    public string usuario { get { return txt_usuario.Text.Trim(); } }
    public DateTime fecha_inicio { get { if (cp_inicio.SelectedValue.HasValue == true) return cp_inicio.SelectedDate; else return DateTime.Parse("12/12/9999"); } }
    public DateTime fecha_fin { get { if (cp_fin.SelectedValue.HasValue == true) return cp_fin.SelectedDate; else return DateTime.Parse("12/12/9999"); } }
    public int tipo_fecha 
    {
        get
        {
            if (cp_inicio.SelectedValue.HasValue == false && cp_fin.SelectedValue.HasValue == false) return 0;
            else if (cp_inicio.SelectedValue.HasValue == true && cp_fin.SelectedValue.HasValue == true) return 3;
            else if (cp_inicio.SelectedValue.HasValue == true) return 1;
            else return 2;
        }
    }
    protected bool num_contratoVisible { get { return lbl_num_contrato_enun.Visible; } set { lbl_num_contrato_enun.Visible = value; txt_num_contrato.Visible = value; rev_num_contrato.Enabled = value; } }
    public string num_contrato { get { if (lbl_num_contrato_enun.Visible == true) return txt_num_contrato.Text.Trim(); else return ""; } }

    protected bool enteroVisible { get { return lbl_entero_enun.Visible; } set { lbl_entero_enun.Visible = value; txt_entero.Visible = value; rv_entero.Enabled = value; } }
    public int entero { get { if (lbl_entero_enun.Visible == true && txt_entero.Text.Trim() != "") return int.Parse(txt_entero.Text.Trim()); else return 0; } }

    protected bool cadenaVisible { get { return lbl_cadena_enun.Visible; } set { lbl_cadena_enun.Visible = value; txt_cadena.Visible = value; } }
    public string cadena { get { if (lbl_cadena_enun.Visible == true) return txt_cadena.Text.Trim(); else return ""; } }
    
    public bool Verificar()
    {
        if (cp_inicio.SelectedValue.HasValue == true && cp_fin.SelectedValue.HasValue == true)
        {
            if (cp_inicio.SelectedDate.Date <= cp_fin.SelectedDate.Date) return true;
            else
            {
                Msg1.Text = "La fecha final no puede ser posterior a la fecha inicial";
                return false;
            }
        }
        else return true;
    }
    
</script>
<asp:Label ID="lbl_reporte" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lbl_reporte_nombre" runat="server" Visible="false"></asp:Label>
<table align="center">
    <tr>
        <td>
            <asp:Panel ID="panel_filtro" runat="server" GroupingText="Filtro del reporte">
                <table class="formTable" align="left" cellpadding="0" cellspacing="0">
                    <tr><td class="formTdMsg"><asp:ValidationSummary ID="vs_auditoria" runat="server" DisplayMode="List" /></td></tr>
                    <tr><td class="formTdMsg"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                </table>
                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="formTdEnun">Usuario:</td>
                        <td class="formTdDato"><asp:TextBox ID="txt_usuario" runat="server" SkinID="txtSingleLine200" MaxLength="35"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="formTdEnun">Fecha:</td>
                        <td class="formTdDato">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td><ew:CalendarPopup ID="cp_inicio" runat="server"></ew:CalendarPopup></td>
                                    <td>-</td>
                                    <td><ew:CalendarPopup ID="cp_fin" runat="server"></ew:CalendarPopup></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTdEnun"><asp:Label ID="lbl_num_contrato_enun" runat="server" Text="Nº contrato:"></asp:Label></td>
                        <td class="formTdDato">
                            <asp:TextBox ID="txt_num_contrato" runat="server" SkinID="txtSingleLine200" MaxLength="15"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="rev_num_contrato" runat="server" ControlToValidate="txt_num_contrato" Display="Dynamic" SetFocusOnError="True" ValidationExpression="<%$ AppSettings:contrato_ExpReg_numero %>" Text="*" ErrorMessage="El número del contrato contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                        </td>
                    </tr>
                    <tr>
                        <td class="formTdEnun"><asp:Label ID="lbl_entero_enun" runat="server"></asp:Label></td>
                        <td class="formTdDato">
                            <asp:TextBox ID="txt_entero" runat="server" SkinID="txtSingleLine200" MaxLength="9"></asp:TextBox>
                            <asp:RangeValidator ID="rv_entero" runat="server" ControlToValidate="txt_entero" Display="Dynamic" Type="integer" MinimumValue="0" MaximumValue="999999999" Operator="DataTypeCheck" Text="*" ErrorMessage="El número debe ser un entero positivo"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTdEnun"><asp:Label ID="lbl_cadena_enun" runat="server"></asp:Label></td>
                        <td class="formTdDato"><asp:TextBox ID="txt_cadena" runat="server" SkinID="txtSingleLine200" MaxLength="35"></asp:TextBox></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
