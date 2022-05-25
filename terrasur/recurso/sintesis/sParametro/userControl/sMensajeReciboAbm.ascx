<%@ Control Language="C#" ClassName="sMensajeReciboAbm" %>

<script runat="server">
    private int id_mensaje { get { return int.Parse(lbl_id_mensaje.Text); } set { lbl_id_mensaje.Text = value.ToString(); } }
    private bool permiso_update { get { return bool.Parse(lbl_permiso_update.Text); } set { lbl_permiso_update.Text = value.ToString(); } }
    private bool permiso_delete { get { return bool.Parse(lbl_permiso_delete.Text); } set { lbl_permiso_delete.Text = value.ToString(); } }

    public void Cargar()
    {
        if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sMensajeRecibo", "view") == true)
        {
            panel_mensaje_recibo.Visible = true;
            
            btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sMensajeRecibo", "insert");
            permiso_update = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sMensajeRecibo", "update");
            permiso_delete = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sMensajeRecibo", "delete");

            CargarDatosMensajes();
        }
        else { panel_mensaje_recibo.Visible = false; }
    }

    protected void gv_anterior_DataBound(object sender, EventArgs e)
    {
        gv_anterior.Columns[0].Visible = permiso_update;
        gv_anterior.Columns[1].Visible = permiso_delete;
    }

    protected void btn_nuevo_Click(object sender, EventArgs e)
    {
        btn_nuevo.Enabled = false;
        panel_nuevo.Visible = true;
        cp_inicio.SelectedDate = DateTime.Now;
        cp_fin.SelectedDate = DateTime.Now;
        txt_mensaje.Text = "";
        btn_insertar.Visible = true;
        btn_actualizar.Visible = false;
        txt_mensaje.Focus();
    }

    protected void gv_anterior_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "editar")
        {
            id_mensaje = int.Parse(gv_anterior.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            terrasur.sintesis.s_mensaje_recibo mObj = new terrasur.sintesis.s_mensaje_recibo(id_mensaje);

            btn_nuevo.Enabled = false;
            panel_nuevo.Visible = true;
            cp_inicio.SelectedDate = mObj.fecha_inicio;
            cp_fin.SelectedDate = mObj.fecha_fin;
            txt_mensaje.Text = mObj.mensaje;
            btn_insertar.Visible = false;
            btn_actualizar.Visible = true;
            txt_mensaje.Focus();
        }
        else if (e.CommandName == "eliminar")
        {
            terrasur.sintesis.s_mensaje_recibo mObj = new terrasur.sintesis.s_mensaje_recibo(int.Parse(e.CommandArgument.ToString()));
            if (mObj.Eliminar(Profile.id_usuario) == true)
            {
                Msg1.Text = "El mensaje se eliminó correctamente";
                CargarDatosMensajes();
            }
            else { Msg1.Text = "El mensaje NO se eliminó correctamente"; }
        }
    }

    protected void lb_editar_Click(object sender, ImageClickEventArgs e)
    {
        id_mensaje = terrasur.sintesis.s_mensaje_recibo.IdActual();
        terrasur.sintesis.s_mensaje_recibo mObj = new terrasur.sintesis.s_mensaje_recibo(id_mensaje);

        btn_nuevo.Enabled = false;
        panel_nuevo.Visible = true;
        cp_inicio.SelectedDate = mObj.fecha_inicio;
        cp_fin.SelectedDate = mObj.fecha_fin;
        txt_mensaje.Text = mObj.mensaje;
        btn_insertar.Visible = false;
        btn_actualizar.Visible = true;
        txt_mensaje.Focus();
    }

    protected void lb_eliminar_Click(object sender, ImageClickEventArgs e)
    {
        terrasur.sintesis.s_mensaje_recibo mObj = new terrasur.sintesis.s_mensaje_recibo(terrasur.sintesis.s_mensaje_recibo.IdActual());
        if (mObj.Eliminar(Profile.id_usuario) == true)
        {
            Msg1.Text = "El mensaje se eliminó correctamente";
            CargarDatosMensajes();
        }
        else { Msg1.Text = "El mensaje NO se eliminó correctamente"; }
    }


    protected void btn_insertar_Click(object sender, EventArgs e)
    {
        if (terrasur.sintesis.s_mensaje_recibo.Verificar(true, 0, cp_inicio.SelectedDate, cp_fin.SelectedDate) == false)
        {
            if (new terrasur.sintesis.s_mensaje_recibo(cp_inicio.SelectedDate, cp_fin.SelectedDate, txt_mensaje.Text.Trim()).Insertar(Profile.id_usuario) == true)
            {
                Msg1.Text = "El mensaje se registró correctamente";
                CargarDatosMensajes();
            }
            else { Msg1.Text = "El mensaje NO se registró correctamente"; }
        }
        else { Msg1.Text = "El periodo definido para el mensaje es incorrecto"; }
    }

    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        if (terrasur.sintesis.s_mensaje_recibo.Verificar(false, id_mensaje, cp_inicio.SelectedDate, cp_fin.SelectedDate) == false)
        {
            if (new terrasur.sintesis.s_mensaje_recibo(id_mensaje, cp_inicio.SelectedDate, cp_fin.SelectedDate, txt_mensaje.Text.Trim()).Actualizar(Profile.id_usuario) == true)
            {
                Msg1.Text = "El mensaje se actualizó correctamente";
                CargarDatosMensajes();
            }
            else { Msg1.Text = "El mensaje NO se actualizó correctamente"; }
        }
        else { Msg1.Text = "El periodo definido para el mensaje es incorrecto"; }
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        CargarDatosMensajes();
    }
    
    
    protected void CargarDatosMensajes()
    {
        btn_nuevo.Enabled = true;
        panel_nuevo.Visible = false;
        int id_mensaje_actual = terrasur.sintesis.s_mensaje_recibo.IdActual();
        if (id_mensaje_actual > 0)
        {
            terrasur.sintesis.s_mensaje_recibo mObj = new terrasur.sintesis.s_mensaje_recibo(id_mensaje_actual);
            lbl_actual_periodo.Text = "Periodo: " + mObj.periodo + " (" + mObj.nombre_usuario + ")";
            lbl_actual_mensaje.Text = mObj.mensaje;
            lb_editar.Visible = permiso_update;
            lb_eliminar.Visible = permiso_delete;
        }
        else
        {
            lbl_actual_periodo.Text = "---";
            lbl_actual_mensaje.Text = "";
            lb_editar.Visible = false;
            lb_eliminar.Visible = false;
        }
        gv_anterior.DataBind();
    }

    protected string MensajeCorto(string m)
    {
        if (m.Length > 50) { return m.Substring(0, 50) + "..."; }
        else { return m; }
    }
</script>
<asp:Label ID="lbl_id_mensaje" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_permiso_update" runat="server" Text="false" Visible="false"></asp:Label>
<asp:Label ID="lbl_permiso_delete" runat="server" Text="false" Visible="false"></asp:Label>

<asp:Panel ID="panel_mensaje_recibo" runat="server" GroupingText="Mensajes de los recibos">
    <table align="left" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" colspan="2">
                <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo mensaje" OnClick="btn_nuevo_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Panel ID="panel_nuevo" runat="server" GroupingText="Datos del mensaje" Visible="false" DefaultButton="btn_cancelar">
                    <table class="formTable">
                        <tr>
                            <td class="formTdEnun">Periodo:</td>
                            <td class="formTdDato">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td><ew:CalendarPopup ID="cp_inicio" runat="server"></ew:CalendarPopup></td>
                                        <td>&nbsp;-&nbsp;</td>
                                        <td><ew:CalendarPopup ID="cp_fin" runat="server"></ew:CalendarPopup></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTdEnun">Mensaje:</td>
                            <td class="formTdDato">
                                <table cellpadding="0" cellspacing="0">
                                    <tr><td><asp:Label ID="lbl_mensaje_limite" runat="server" Text="Límite máximo: 400 caracteres; no se admiten saltos de línea" SkinID="lblEnun"></asp:Label></td></tr>
                                    <tr><td><asp:TextBox ID="txt_mensaje" runat="server" TextMode="MultiLine" MaxLength="400" Height="50" Width="350"></asp:TextBox></td></tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table cellpadding="0" cellspacing="0" align="right">
                                    <tr>
                                        <td><asp:Button ID="btn_insertar" runat="server" Text="Registrar" OnClick="btn_insertar_Click" /></td>
                                        <td><asp:Button ID="btn_actualizar" runat="server" Text="Actualizar" OnClick="btn_actualizar_Click" /></td>
                                        <td><asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" OnClick="btn_cancelar_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="formTdMsg" colspan="2">
                <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr><td align="left"><asp:Label ID="lbl_actual_enun" runat="server" Text="Actual:" SkinID="lblEnun"></asp:Label></td></tr>
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="lb_editar" runat="server" Text="Editar" ImageUrl="~/images/gv/edit.gif" OnClick="lb_editar_Click" />
                            <asp:ImageButton ID="lb_eliminar" runat="server" Text="Eliminar" ImageUrl="~/images/gv/delete.gif" OnClientClick="return confirm('¿Esta seguro que desea eliminar este mensaje?');" OnClick="lb_eliminar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left">
                <table cellpadding="0" cellspacing="0">
                    <tr><td align="left"><asp:Label ID="lbl_actual_periodo" runat="server" SkinID="lblDato"></asp:Label></td></tr>
                    <tr>
                        <td align="left">
                            <asp:Panel ID="panel_actual_mensaje" runat="server" Width="370">
                                <asp:Label ID="lbl_actual_mensaje" runat="server" SkinID="lblDato"></asp:Label>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top"><asp:Label ID="lbl_anterior_enun" runat="server" Text="Anterior(es):" SkinID="lblEnun"></asp:Label></td>
            <td align="left">
                <asp:GridView ID="gv_anterior" runat="server" DataSourceID="ods_lista_mensajes_anteriores" DataKeyNames="id_mensaje" AutoGenerateColumns="false" OnDataBound="gv_anterior_DataBound" OnRowCommand="gv_anterior_RowCommand">
                    <Columns>
                        <asp:ButtonField CommandName="editar" Text="Editar" ButtonType="Image" ImageUrl="~/images/gv/edit.gif" />
                        <asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_delete" runat="server" SkinID="btnDelete" CommandName="eliminar" CommandArgument='<%# Eval("id_mensaje") %>' OnClientClick="return confirm('¿Esta seguro que desea eliminar este mensaje?');" /></ItemTemplate></asp:TemplateField>
                        <%--<asp:BoundField HeaderText="Periodo" DataField="periodo" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderText="Usuario" DataField="usuario" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" />--%>
                        <asp:TemplateField HeaderText="Mensaje">
                            <ItemTemplate>
                                <asp:Panel ID="panel_anterior_mensaje" runat="server" Width="350">
                                    <table cellpadding="0" cellspacing="0" align="left">
                                        <tr><td><asp:Label ID="lbl_periodo_usuario" runat="server" Text='<%# String.Format("Periodo: {0} ({1})",Eval("periodo").ToString(),Eval("usuario").ToString()) %>'></asp:Label></td></tr>
                                        <tr><td><asp:Label ID="lbl_anterior_mensaje" runat="server" Text='<%# MensajeCorto(Eval("mensaje").ToString()) %>' ToolTip='<%# Eval("mensaje") %>'></asp:Label></td></tr>
                                    </table>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>---</EmptyDataTemplate>
                </asp:GridView>
                <%--[id_mensaje],[usuario],[periodo],[mensaje]--%>
                <asp:ObjectDataSource ID="ods_lista_mensajes_anteriores" runat="server" TypeName="terrasur.sintesis.s_mensaje_recibo" SelectMethod="Lista_anteriores">
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Panel>
