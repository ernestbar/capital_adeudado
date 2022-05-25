<%@ Control Language="C#" ClassName="urbanizacionPrioridadAbm" %>
<%@ Register src="~/recurso/inventario/seguimientoObras/userControl/urbDatosView.ascx" tagname="urbDatosView" tagprefix="uc1" %>

<script runat="server">
    private int _id_urbanizacion { get { return int.Parse(lbl_id_urbanizacion.Text); } set { lbl_id_urbanizacion.Text = value.ToString(); } }

    public void CargarInsertar(int Id_urbanizacion)
    {
        _id_urbanizacion = Id_urbanizacion;
        urbDatosView1.id_urbanizacion = _id_urbanizacion;
        btn_cambiar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "prioridad");
        panel_prioridad.Visible = false;
    }

    protected void btn_cambiar_Click(object sender, EventArgs e)
    {
        btn_cambiar.Visible = false;
        panel_prioridad.Visible = true;
        CargarFormulario();
    }

    protected void btn_insertar_Click(object sender, EventArgs e)
    {
        //Se verifica si el nuevo registro es diferente al anterior
        terrasur.so.so_urbanizacion_prioridad up = new terrasur.so.so_urbanizacion_prioridad(0, _id_urbanizacion);
        bool es_diferente = false;
        if (int.Parse(rbl_prioridad.SelectedValue) != up.id_prioridad) { es_diferente = true; }

        if (up.fecha_planificada.Date == DateTime.Now.Date)
        { if (cp_fecha_planificada.SelectedValue.HasValue == true) { es_diferente = true; } }
        else
        {
            if (cp_fecha_planificada.SelectedValue.HasValue == false) { es_diferente = true; }
            else { if (cp_fecha_planificada.SelectedDate != up.fecha_planificada.Date) { es_diferente = true; } }
        }

        if (es_diferente == false) { Msg1.Text = "No existen cambios respecto a los datos vigentes"; }
        else
        {
            DateTime fecha_planificada_elegida = DateTime.Parse("01/01/1900");
            if (cp_fecha_planificada.SelectedValue.HasValue == true) { fecha_planificada_elegida = cp_fecha_planificada.SelectedDate.Date; }
            terrasur.so.so_urbanizacion_prioridad upObj = new terrasur.so.so_urbanizacion_prioridad(_id_urbanizacion, int.Parse(rbl_prioridad.SelectedValue), Profile.id_usuario, fecha_planificada_elegida, txt_observacion.Text.Trim());
            if (upObj.Insertar())
            {
                Msg1.Text = "Los datos se registraron correctamente";
                urbDatosView1.id_urbanizacion = _id_urbanizacion;
                btn_cambiar.Visible = true;
                panel_prioridad.Visible = false;
            }
            else { Msg1.Text = "Los datos NO se registraron correctamente"; }
        }
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        urbDatosView1.id_urbanizacion = _id_urbanizacion;
        btn_cambiar.Visible = true;
        panel_prioridad.Visible = false;
    }

    protected void CargarFormulario()
    {
        terrasur.so.so_urbanizacion_prioridad up = new terrasur.so.so_urbanizacion_prioridad(0, _id_urbanizacion);
        if (up.id_prioridad > 0)
        {
            if (rbl_prioridad.Items.FindByValue(up.id_prioridad.ToString()) == null) { rbl_prioridad.DataBind(); }
            if (rbl_prioridad.Items.FindByValue(up.id_prioridad.ToString()) != null) { rbl_prioridad.SelectedValue = up.id_prioridad.ToString(); }
        }
        else { rbl_prioridad.SelectedValue = (new terrasur.so.so_prioridad(0, "media")).id_prioridad.ToString(); }

        if (up.fecha_planificada.Date != DateTime.Parse("01/01/1900")) { cp_fecha_planificada.SelectedDate = up.fecha_planificada.Date; } else { cp_fecha_planificada.SelectedValue = null; }
        txt_observacion.Text = "";
    }
    
</script>
<asp:Label ID="lbl_id_urbanizacion" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr><td class="priTdTitle">Prioridad y Planificación</td></tr>
    <%--<tr>
        <td class="formTdTitle">
            <asp:Label ID="lbl_title" runat="server" Text="Prioridad y Planificación"></asp:Label>
        </td>
    </tr>--%>
    <tr><td><uc1:urbDatosView ID="urbDatosView1" runat="server" /></td></tr>
    <tr>
        <td align="center">
            <asp:Button ID="btn_cambiar" runat="server" Text="Cambiar" CausesValidation="false" OnClick="btn_cambiar_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td>
                        <asp:Panel ID="panel_prioridad" runat="server" Visible="false" DefaultButton="btn_insertar" GroupingText="Cambiar Prioridad y Planificación">
                            <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="formTdEnun">Prioridad:</td>
                                    <td class="formTdDato">
                                        <asp:RadioButtonList ID="rbl_prioridad" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" DataSourceID="ods_lista_prioridad" DataTextField="nombre" DataValueField="id_prioridad">
                                        </asp:RadioButtonList>
                                        <%--[id_prioridad],[numero],[codigo],[nombre]--%>
                                        <asp:ObjectDataSource ID="ods_lista_prioridad" runat="server" TypeName="terrasur.so.so_prioridad" SelectMethod="Lista">
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTdEnun">Entrega planificada:</td>
                                    <td class="formTdDato">
                                        <ew:CalendarPopup ID="cp_fecha_planificada" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False">
                                        </ew:CalendarPopup>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTdEnun">Observación:</td>
                                    <td class="formTdDato">
                                        <asp:TextBox ID="txt_observacion" runat="server" TextMode="MultiLine" Width="400" Rows="3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td colspan="2"><asp:Msg ID="Msg1" runat="server"></asp:Msg></td></tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btn_insertar" runat="server" Text="Guardar cambio" OnClick="btn_insertar_Click" />
                                        <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar / Volver" OnClick="btn_cancelar_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

