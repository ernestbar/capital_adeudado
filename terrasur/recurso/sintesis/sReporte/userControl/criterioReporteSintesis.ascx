<%@ Control Language="C#" ClassName="criterioReporteSintesis" %>

<script runat="server">
    public void Cargar(bool con_horas)
    {
        if (ddl_eeff.Items.Count == 0) { ddl_eeff.DataBind(); }
        ddl_eeff.SelectedValue = "0";

        if (ddl_sucursal.Items.Count == 0) { ddl_sucursal.DataBind(); }
        ddl_sucursal.SelectedValue = "0";

        txt_usuario.Text = "";
        cp_fecha_inicio.SelectedDate = DateTime.Now;
        cp_fecha_fin.SelectedValue = null;

        tp_fecha_inicio.Visible = con_horas;
        tp_fecha_fin.Visible = con_horas;
        if (con_horas)
        {
            tp_fecha_inicio.SelectedValue = null;
            tp_fecha_fin.SelectedValue = null;
        }
        
        txt_num_contrato.Text = "";
        txt_id_pagopendiente.Text = "";

        txt_num_contrato.Focus();
    }
    
    public int id_eeff { get { return int.Parse(ddl_eeff.SelectedValue); } }
    public int id_sucursal_eeff { get { return int.Parse(ddl_sucursal.SelectedValue); } }
    public string usuario { get { return txt_usuario.Text.Trim(); } }
    public DateTime fecha_inicio
    {
        get
        {
            if (cp_fecha_inicio.SelectedValue.HasValue == true)
            {
                if (tp_fecha_inicio.Visible == true && tp_fecha_inicio.SelectedValue.HasValue == true)
                {
                    return cp_fecha_inicio.SelectedDate.AddHours(tp_fecha_inicio.SelectedTime.Hour).AddMinutes(tp_fecha_inicio.SelectedTime.Minute);
                }
                else { return cp_fecha_inicio.SelectedDate; }
            }
            else { return DateTime.Parse("01/01/1900"); }
        }
    }
    public DateTime fecha_fin
    {
        get
        {
            if (cp_fecha_fin.SelectedValue.HasValue == true)
            {
                if (tp_fecha_fin.Visible == true && tp_fecha_fin.SelectedValue.HasValue == true)
                {
                    return cp_fecha_fin.SelectedDate.AddHours(tp_fecha_fin.SelectedTime.Hour).AddMinutes(tp_fecha_fin.SelectedTime.Minute).AddSeconds(59);
                }
                else { return cp_fecha_fin.SelectedDate.AddDays(1).AddSeconds(-1); }
            }
            else { return DateTime.Parse("01/01/5900"); }
        }
    }
    public string num_contrato { get { return txt_num_contrato.Text.Trim(); } }
    public int id_pagopendiente { get { int id = 0; if (int.TryParse(txt_id_pagopendiente.Text.Trim(), out id) == true) { return id; } else { return 0; } } }

    public string string_eeff { get { return ddl_eeff.SelectedItem.Text; } }
    public string string_sucursal_eeff { get { return ddl_sucursal.SelectedItem.Text; } }
    public string string_fechas
    {
        get
        {
            if (cp_fecha_inicio.SelectedValue.HasValue == true && cp_fecha_fin.SelectedValue.HasValue == true)
            {
                DateTime f_ini = cp_fecha_inicio.SelectedDate;
                if (tp_fecha_inicio.Visible == true && tp_fecha_inicio.SelectedValue.HasValue == true)
                {
                    f_ini.AddHours(tp_fecha_inicio.SelectedTime.Hour).AddMinutes(tp_fecha_inicio.SelectedTime.Minute);
                }
                DateTime f_fin = cp_fecha_fin.SelectedDate;
                if (tp_fecha_fin.Visible == true && tp_fecha_fin.SelectedValue.HasValue == true)
                {
                    f_fin.AddHours(tp_fecha_fin.SelectedTime.Hour).AddMinutes(tp_fecha_fin.SelectedTime.Minute).AddSeconds(59);
                }
                else { f_fin.AddDays(1).AddSeconds(-1); }

                
                if ((f_ini.Hour > 0 || f_ini.Minute > 0) && (f_fin.Hour > 0 || f_fin.Minute > 0))
                {
                    return String.Format("{0:dd/MM/yyyy HH:mm:ss}", f_ini) + " - " + String.Format("{0:dd/MM/yyyy HH:mm:ss}", f_fin);
                }
                else if ((f_ini.Hour > 0 || f_ini.Minute > 0) && (f_fin.Hour == 0 && f_fin.Minute == 0))
                {
                    return String.Format("{0:dd/MM/yyyy HH:mm:ss}", f_ini) + " - " + f_fin.ToString("d");
                }
                else if ((f_ini.Hour == 0 && f_ini.Minute == 0) && (f_fin.Hour > 0 || f_fin.Minute > 0))
                {
                    return f_ini.ToString("d") + " - " + String.Format("{0:dd/MM/yyyy HH:mm:ss}", f_fin);
                }
                else { return f_ini.ToString("d") + " - " + f_fin.ToString("d"); }
            }
            else if (cp_fecha_inicio.SelectedValue.HasValue == true && cp_fecha_fin.SelectedValue.HasValue == false)
            {
                if (tp_fecha_inicio.Visible == true && tp_fecha_inicio.SelectedValue.HasValue == true)
                {
                    return "Desde el " + String.Format("{0:dd/MM/yyyy HH:mm:ss}", cp_fecha_inicio.SelectedDate.AddHours(tp_fecha_inicio.SelectedTime.Hour).AddMinutes(tp_fecha_inicio.SelectedTime.Minute));
                }
                else { return "Desde el " + cp_fecha_inicio.SelectedDate.ToString("d"); }
            }
            else if (cp_fecha_inicio.SelectedValue.HasValue == false && cp_fecha_fin.SelectedValue.HasValue == true)
            {
                if (tp_fecha_fin.Visible == true && tp_fecha_fin.SelectedValue.HasValue == true)
                {
                    return "Hasta el " + String.Format("{0:dd/MM/yyyy HH:mm:ss}", cp_fecha_fin.SelectedDate.AddHours(tp_fecha_fin.SelectedTime.Hour).AddMinutes(tp_fecha_fin.SelectedTime.Minute).AddSeconds(59));
                }
                else { return "Hasta el " + String.Format("{0:dd/MM/yyyy HH:mm:ss}", cp_fecha_fin.SelectedDate.AddDays(1).AddSeconds(-1)); }
            }
            else { return ""; }
        }
    }
    public string string_id_pagopendiente { get { int id = 0; if (int.TryParse(txt_id_pagopendiente.Text.Trim(), out id) == true) { return id.ToString(); } else { return ""; } } }

    protected void ddl_eeff_DataBound(object sender, EventArgs e) { ddl_eeff.Items.Insert(0, new ListItem("Todos", "0")); }

    protected void ddl_sucursal_DataBound(object sender, EventArgs e) { ddl_sucursal.Items.Insert(0, new ListItem("Todos", "0")); }
</script>
<asp:Panel ID="panel_criterio" runat="server" GroupingText="Criterio de selección">
<table class="formHorTable" align="center">
    <tr>
        <td class="formHorTdEnun">Lugar (EEFF / Sucursal)</td>
        <td class="formHorTdEnun">Usuario</td>
        <td class="formHorTdEnun">Fecha</td>
        <td class="formHorTdEnun">Nº de contrato</td>
        <td class="formHorTdEnun">Id_pagopendiente</td>
    </tr>
    <tr>
        <td class="formHorTdDato">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:DropDownList ID="ddl_eeff" runat="server" AutoPostBack="true" 
                            DataSourceID="ods_lista_eeff" DataValueField="id_eeff" DataTextField="nombre" 
                            OnDataBound="ddl_eeff_DataBound">
                        </asp:DropDownList>
                        <%--[id_eeff],[codigo],[nombre],[num_sucursales]--%>
                        <asp:ObjectDataSource ID="ods_lista_eeff" runat="server" TypeName="terrasur.sintesis.s_eeff" SelectMethod="Lista">
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_sucursal" runat="server" DataSourceID="ods_lista_sucursal" DataValueField="id_sucursal_eeff" DataTextField="nombre" OnDataBound="ddl_sucursal_DataBound">
                        </asp:DropDownList>
                        <%--[id_sucursal_eeff],[codigo],[nombre]--%>
                        <asp:ObjectDataSource ID="ods_lista_sucursal" runat="server" TypeName="terrasur.sintesis.s_sucursal_eeff" SelectMethod="Lista">
                            <SelectParameters>
                                <asp:ControlParameter Name="Id_eeff" Type="Int32" ControlID="ddl_eeff" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
        </td>
        <td class="formHorTdDato">
            <asp:TextBox ID="txt_usuario" runat="server" SkinID="txtSingleLine100" MaxLength="50"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td><ew:CalendarPopup ID="cp_fecha_inicio" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                    <td><ew:TimePicker ID="tp_fecha_inicio" runat="server" ShowClearTime="true" Nullable="true" ClearTimeText="No definir" DisableTextBoxEntry="false"></ew:TimePicker></td>
                    <td>&nbsp;&nbsp;-&nbsp;&nbsp;</td>
                    <td><ew:CalendarPopup ID="cp_fecha_fin" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup></td>
                    <td><ew:TimePicker ID="tp_fecha_fin" runat="server" ShowClearTime="true" Nullable="true" ClearTimeText="No definir" DisableTextBoxEntry="false"></ew:TimePicker></td>
                </tr>
            </table>
        </td>
        <td class="formHorTdDato">
            <asp:TextBox ID="txt_num_contrato" runat="server" SkinID="txtSingleLine100" MaxLength="50"></asp:TextBox>
        </td>
        <td class="formHorTdDato">
            <asp:TextBox ID="txt_id_pagopendiente" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
        </td>
    </tr>
</table>
</asp:Panel>