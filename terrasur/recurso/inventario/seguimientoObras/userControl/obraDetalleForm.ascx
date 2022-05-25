<%@ Control Language="C#" ClassName="obraDetalleForm" %>

<script runat="server">
    public event EventHandler Eleccion;
    protected virtual void RealizarEleccion(object sender) { if (this.Eleccion != null) this.Eleccion(sender, new EventArgs()); }
    
    private bool es_nuevo { get { return bool.Parse(lbl_es_nuevo.Text); } set { lbl_es_nuevo.Text = value.ToString(); } }
    private int id_urbanizacion { get { return int.Parse(lbl_id_urbanizacion.Text); } set { lbl_id_urbanizacion.Text = value.ToString(); } }
    private int id_tipoobra { get { return int.Parse(lbl_id_tipoobra.Text); } set { lbl_id_tipoobra.Text = value.ToString(); } }

    public void CargarNuevo(int Id_urbanizacion, int Id_tipoobra)
    {
        es_nuevo = true;
        id_urbanizacion = Id_urbanizacion;
        id_tipoobra = Id_tipoobra;

        //Fecha de planificación
        cp_fecha.Enabled = true;
        cp_fecha.SelectedValue = null;
        btn_fecha_cambiar.Visible = false;
        btn_fecha_insert.Visible = false;
        btn_fecha_cancel.Visible = false;

        //Estado
        ddl_estado.Enabled = true;
        ddl_estado.DataBind();
        ddl_estado.Items.FindByValue(new terrasur.so.so_estadoObra(0, 0, "suspendido").id_estado.ToString()).Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_suspender");
        
        ddl_estado.SelectedValue = new terrasur.so.so_estadoObra(0, 0, "pendiente").id_estado.ToString();
        //rbl_estado.SelectedValue = rbl_estado.Items.FindByValue("Pendiente").Value;
        rbl_avance.Enabled = true;
        rbl_avance.Visible = true;
        rbl_avance.SelectedValue = "0";
        btn_estado_cambiar.Visible = false;
        btn_estado_update.Visible = false;
        btn_estado_cancel.Visible = false;

        //Observación
        r_observaciones.Visible = false;
        btn_obs_agregar.Visible = false;
        panel_observacion.Visible = true;
        txt_observacion.Text = "";
        btn_obs_insertar.Visible = false;
        btn_obs_cancelar.Visible = false;
    }

    public bool RegistrarNuevo()
    {
        bool correcto = true;
        if (terrasur.so.so_obraMaestro.Verificar(id_urbanizacion) == false)
        {
            if ((new terrasur.so.so_obraMaestro(id_urbanizacion, Profile.id_usuario)).Insertar() == false)
            { correcto = false; Msg1.Text = "El registro Obra-Maestro es incorrecto"; }
        }

        //Se registra  so_obraDetalle
        DateTime Fecha_planificada = DateTime.Parse("01/01/1900");
        if (cp_fecha.SelectedValue.HasValue == true) { Fecha_planificada = cp_fecha.SelectedDate; }
        terrasur.so.so_obraDetalle odObj = new terrasur.so.so_obraDetalle(id_urbanizacion, id_tipoobra, Profile.id_usuario, Fecha_planificada);
        if (odObj.Insertar())
        {
            //Se registra el estado y el avance
            decimal avance = decimal.Parse(rbl_avance.SelectedValue);
            if (ddl_estado.SelectedValue == new terrasur.so.so_estadoObra(0, 0, "concluido").id_estado.ToString()) { avance = 100; }
            else if (ddl_estado.SelectedValue == new terrasur.so.so_estadoObra(0, 0, "suspendido").id_estado.ToString()) { avance = 0; }

            terrasur.so.so_estadoObra_detalle eodObj = new terrasur.so.so_estadoObra_detalle(int.Parse(ddl_estado.SelectedValue), id_urbanizacion, id_tipoobra, Profile.id_usuario, avance);
            if (eodObj.Insertar())
            {
                if (txt_observacion.Text.Trim() != "")
                {
                    if (new terrasur.so.so_observacion(0, eodObj.id_estadoobradetalle, Profile.id_usuario, txt_observacion.Text.Trim()).Insertar())
                    {
                        RealizarEleccion(this);
                    }
                    else { correcto = false; Msg1.Text = "El registro de la observación es incorrecto"; }
                }
            }
            else { correcto = false; Msg1.Text = "El registro del estado es incorrecto"; }
        }
        else { correcto = false; Msg1.Text = "El registro Obra-Detalle es incorrecto"; }
        return correcto;
    }

    public void CargarAntiguo(int Id_urbanizacion, int Id_tipoobra)
    {
        es_nuevo = false;
        id_urbanizacion = Id_urbanizacion;
        id_tipoobra = Id_tipoobra;
        terrasur.so.so_obraDetalle odObj = new terrasur.so.so_obraDetalle(id_urbanizacion, id_tipoobra);

        //Fecha de planificación
        cp_fecha.Enabled = false;
        if (odObj.fecha_planificada.Date == DateTime.Parse("01/01/1900")) { cp_fecha.SelectedValue = null; }
        else { cp_fecha.SelectedDate = odObj.fecha_planificada; }
        btn_fecha_cambiar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_fechaPlanificacion");
        btn_fecha_insert.Visible = false;
        btn_fecha_cancel.Visible = false;

        //Estado
        ddl_estado.DataBind();
        ddl_estado.SelectedValue = odObj.id_estado.ToString();
        if (odObj.estado_codigo == "pendiente")
        {
            ddl_estado.Items.FindByValue(new terrasur.so.so_estadoObra(0, 0, "suspendido").id_estado.ToString()).Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_suspender");
            rbl_avance.Visible = true;
            if (rbl_avance.Items.FindByValue(odObj.avance.ToString()) != null) { rbl_avance.SelectedValue = odObj.avance.ToString(); }
            else { rbl_avance.SelectedValue = "0"; }
        }
        else if (odObj.estado_codigo == "concluido")
        {
            ddl_estado.Items.FindByValue(new terrasur.so.so_estadoObra(0, 0, "suspendido").id_estado.ToString()).Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_suspender");
            rbl_avance.Visible = false;
            rbl_avance.SelectedValue = "90";
        }
        else if (odObj.estado_codigo == "suspendido")
        {
            rbl_avance.Visible = false;
            if (rbl_avance.Items.FindByValue(odObj.avance.ToString()) != null) { rbl_avance.SelectedValue = odObj.avance.ToString(); }
            else { rbl_avance.SelectedValue = "0"; }
        }
        ddl_estado.Enabled = false;
        rbl_avance.Enabled = false;
        btn_estado_cambiar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_avance");
        btn_estado_update.Visible = false;
        btn_estado_cancel.Visible = false;

        //Observación
        r_observaciones.Visible = true;
        r_observaciones.DataBind();
        btn_obs_agregar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_obs");
        panel_observacion.Visible = false;
        txt_observacion.Text = "";
    }

    protected string EncabezadoObservacion(object Fecha, string Estado, string Usuario)
    { return ((DateTime)Fecha).ToString("d") + " - Estado: " + Estado + " (" + Usuario + ")"; }


    
    protected void ddl_estado_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_estado.SelectedValue == new terrasur.so.so_estadoObra(0, 0, "pendiente").id_estado.ToString())
        { rbl_avance.Visible = true; }
        else { rbl_avance.Visible = false; }
    }

    
    
    protected void btn_fecha_cambiar_Click(object sender, EventArgs e)
    {
        cp_fecha.Enabled = true;
        btn_fecha_cambiar.Visible = false;
        btn_fecha_insert.Visible = true;
        btn_fecha_cancel.Visible = true;
    }
    protected void btn_fecha_insert_Click(object sender, EventArgs e)
    {
        DateTime Fecha_planificada = DateTime.Parse("01/01/1900");
        if (cp_fecha.SelectedValue.HasValue == true) { Fecha_planificada = cp_fecha.SelectedDate; }
        terrasur.so.so_obraDetalle odObj = new terrasur.so.so_obraDetalle(id_urbanizacion, id_tipoobra, Profile.id_usuario, Fecha_planificada);
        
        if (odObj.Actualizar())
        {
            Msg1.Text = "La fecha planificada se registró correctamente";
            cp_fecha.Enabled = false;
            btn_fecha_cambiar.Visible = true;
            btn_fecha_insert.Visible = false;
            btn_fecha_cancel.Visible = false;
            RealizarEleccion(sender);
        }
        else { Msg1.Text = "La fecha planificada NO se registró correctamente"; }
    }
    protected void btn_fecha_cancel_Click(object sender, EventArgs e)
    {
        cp_fecha.Enabled = false;
        btn_fecha_cambiar.Visible = true;
        btn_fecha_insert.Visible = false;
        btn_fecha_cancel.Visible = false;
    }





    protected void btn_estado_cambiar_Click(object sender, EventArgs e)
    {
        ddl_estado.Enabled = true;
        ddl_estado.Items.FindByValue(new terrasur.so.so_estadoObra(0, 0, "suspendido").id_estado.ToString()).Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "obras_suspender");
        rbl_avance.Enabled = true;
        btn_estado_cambiar.Visible = false;
        btn_estado_update.Visible = true;
        btn_estado_cancel.Visible = true;
    }
    protected void btn_estado_update_Click(object sender, EventArgs e)
    {
        ddl_estado.Enabled = false;
        rbl_avance.Enabled = false;

        //decimal avance = 0;
        decimal avance = decimal.Parse(rbl_avance.SelectedValue);
        if (ddl_estado.SelectedValue == new terrasur.so.so_estadoObra(0, 0, "concluido").id_estado.ToString()) { avance = 100; }
        terrasur.so.so_estadoObra_detalle eodObj = new terrasur.so.so_estadoObra_detalle(int.Parse(ddl_estado.SelectedValue), id_urbanizacion, id_tipoobra, Profile.id_usuario, avance);
        if (eodObj.Insertar())
        {
            Msg1.Text = "El estado de la obra se registró correctamente";
            ddl_estado.Enabled = false;
            rbl_avance.Enabled = false;
            btn_estado_cambiar.Visible = true;
            btn_estado_update.Visible = false;
            btn_estado_cancel.Visible = false;
            RealizarEleccion(sender);
        }
        else { Msg1.Text = "El estado de la obra NO se registró correctamente"; }
    }
    protected void btn_estado_cancel_Click(object sender, EventArgs e)
    {
        ddl_estado.Enabled = false;
        rbl_avance.Enabled = false;
        btn_estado_cambiar.Visible = true;
        btn_estado_update.Visible = false;
        btn_estado_cancel.Visible = false;
    }

    
    protected void btn_obs_agregar_Click(object sender, EventArgs e)
    {
        btn_obs_agregar.Visible = false;
        panel_observacion.Visible = true;
        txt_observacion.Text = "";
        txt_observacion.Focus();
        btn_obs_insertar.Visible = true;
        btn_obs_cancelar.Visible = true;
    }
    protected void btn_obs_insertar_Click(object sender, EventArgs e)
    {
        if (txt_observacion.Text.Trim() != "")
        {
            int id_estadoobradetalle = terrasur.so.so_estadoObra_detalle.IdEstadoObraDetalle_actual(id_urbanizacion, id_tipoobra);
            if (new terrasur.so.so_observacion(0, id_estadoobradetalle, Profile.id_usuario, txt_observacion.Text.Trim()).Insertar())
            {
                Msg1.Text = "La observación se registró correctamente";
                r_observaciones.DataBind();
                btn_obs_agregar.Visible = true;
                panel_observacion.Visible = false;
                RealizarEleccion(sender);
            }
            else { Msg1.Text = "La observación NO se registró correctamente"; }
        }
        else { Msg1.Text = "Debe introducir una obseración"; }
    }
    protected void btn_obs_cancelar_Click(object sender, EventArgs e)
    {
        r_observaciones.DataBind();
        btn_obs_agregar.Visible = true;
        panel_observacion.Visible = false;
    }
</script>
<asp:Label ID="lbl_es_nuevo" runat="server" Text="true" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_urbanizacion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_tipoobra" runat="server" Text="0" Visible="false"></asp:Label>
<table cellpadding="0" cellspacing="0" align="center">
    <tr>
        <td colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">F.Planif.:</td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="cp_fecha" runat="server" ShowClearDate="true" Nullable="True" ClearDateText="Ninguna fecha" DisableTextBoxEntry="False"></ew:CalendarPopup>
            <asp:LinkButton ID="btn_fecha_cambiar" runat="server" Text="Cambiar" OnClick="btn_fecha_cambiar_Click"></asp:LinkButton>
            <asp:LinkButton ID="btn_fecha_insert" runat="server" Visible="false" Text="Actualizar" OnClick="btn_fecha_insert_Click"></asp:LinkButton>
            <asp:LinkButton ID="btn_fecha_cancel" runat="server" Visible="false" Text="Cancelar" OnClick="btn_fecha_cancel_Click"></asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Estado:</td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:DropDownList ID="ddl_estado" runat="server"  DataSourceID="ods_lista_estado" AutoPostBack="true" DataTextField="nombre" DataValueField="id_estado" OnSelectedIndexChanged="ddl_estado_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%--[id_estado],[orden],[codigo],[nombre]--%>
                        <asp:ObjectDataSource ID="ods_lista_estado" runat="server" TypeName="terrasur.so.so_estadoObra" SelectMethod="Lista">
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbl_avance" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                            <asp:ListItem Text="40" Value="40"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                            <asp:ListItem Text="60" Value="60"></asp:ListItem>
                            <asp:ListItem Text="70" Value="70"></asp:ListItem>
                            <asp:ListItem Text="80" Value="80"></asp:ListItem>
                            <asp:ListItem Text="90" Value="90"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td><asp:LinkButton ID="btn_estado_cambiar" runat="server" Text="Cambiar" OnClick="btn_estado_cambiar_Click"></asp:LinkButton></td>
                    <td><asp:LinkButton ID="btn_estado_update" runat="server" Visible="false" Text="Actualizar" OnClick="btn_estado_update_Click"></asp:LinkButton></td>
                    <td><asp:LinkButton ID="btn_estado_cancel" runat="server" Visible="false" Text="Cancelar" OnClick="btn_estado_cancel_Click"></asp:LinkButton></td>
                </tr>
            </table>
            <%--<asp:RadioButtonList ID="rbl_estado" runat="server" DataSourceID="ods_lista_estado" DataTextField="nombre" DataValueField="id_estado" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
            </asp:RadioButtonList>
            <asp:TextBox ID="txt_avance" runat="server" SkinID="txtSingleLine100"></asp:TextBox>
            <asp:Label ID="lbl_avance_enun" runat="server" Text="% avance"></asp:Label>--%>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Observ.:</td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0" align="left">
                <tr>
                    <td>
                        <asp:Repeater ID="r_observaciones" runat="server" DataSourceID="ods_lista_observaciones">
                            <HeaderTemplate><table cellpadding="0" cellspacing="0" width="550"></HeaderTemplate>
                            <ItemTemplate>
                                <tr><td align="left"><asp:Label ID="lbl_encabezado" runat="server" Text='<%# EncabezadoObservacion(Eval("fecha"),Eval("estado").ToString(),Eval("usuario").ToString()) %>'></asp:Label></td></tr>
                                <tr><td align="left"><asp:Label ID="lbl_observacion" runat="server" Text='<%# Eval("texto") %>'></asp:Label></td></tr>
                            </ItemTemplate>
                            <SeparatorTemplate><tr><td><hr /></td></tr></SeparatorTemplate>
                            <FooterTemplate></table></FooterTemplate>
                        </asp:Repeater>
                        <%--[id_observacion],[usuario],[estado],[fecha],[texto]--%>
                        <asp:ObjectDataSource ID="ods_lista_observaciones" runat="server" TypeName="terrasur.so.so_observacion" SelectMethod="ListaPorObra">
                            <SelectParameters>
                                <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="lbl_id_urbanizacion" PropertyName="Text" />
                                <asp:ControlParameter Name="Id_tipoobra" Type="Int32" ControlID="lbl_id_tipoobra" PropertyName="Text" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="btn_obs_agregar" runat="server" Text="Agregar" CausesValidation="false" OnClick="btn_obs_agregar_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Panel ID="panel_observacion" runat="server" Visible="false">
                            <table>
                                <tr><td><asp:TextBox ID="txt_observacion" runat="server" TextMode="MultiLine" Width="400" Rows="3" ValidationGroup="obs"></asp:TextBox></td></tr>
                                <tr><td><asp:ValidationSummary ID="vs_obs" runat="server" ValidationGroup="obs" DisplayMode="List" /></td></tr>
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btn_obs_insertar" runat="server" Text="Guardar" CausesValidation="true" ValidationGroup="obs" OnClick="btn_obs_insertar_Click" />
                                        <asp:Button ID="btn_obs_cancelar" runat="server" Text="Cancelar/Volver" CausesValidation="false" OnClick="btn_obs_cancelar_Click" />
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