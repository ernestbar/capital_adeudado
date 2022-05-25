<%@ Control Language="C#" ClassName="estadoMaestroObservacion" %>
<%@ Register src="~/recurso/inventario/seguimientoObras/userControl/urbDatosView.ascx" tagname="urbDatosView" tagprefix="uc1" %>

<script runat="server">
    private int _id_urbanizacion { get { return int.Parse(lbl_id_urbanizacion.Text); } set { lbl_id_urbanizacion.Text = value.ToString(); } }
    
    public void CargarInsertar(int Id_urbanizacion)
    {
        _id_urbanizacion = Id_urbanizacion;
        urbDatosView1.VerObservacion = false;
        CargarDatosActuales();
        btn_agregar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "seguimientoObras", "observacion");
        panel_observacion.Visible = false;
    }

    protected void btn_agregar_Click(object sender, EventArgs e)
    {
        btn_agregar.Visible = false;
        panel_observacion.Visible = true;
        txt_observacion.Text = "";
        txt_observacion.Focus();
    }


    protected void CargarDatosActuales()
    {
        urbDatosView1.id_urbanizacion = _id_urbanizacion;
        r_observaciones.DataBind();
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        CargarDatosActuales();
        btn_agregar.Visible = true;
        panel_observacion.Visible = false;
    }
    
    protected void btn_insertar_Click(object sender, EventArgs e)
    {
        if (txt_observacion.Text.Trim() != "")
        {
            int id_estadoobramaestro = terrasur.so.so_estadoObra_maestro.IdEstadoObraMaestro(_id_urbanizacion);
            if (id_estadoobramaestro == 0)
            {
                if (terrasur.so.so_obraMaestro.Verificar(_id_urbanizacion) == false)
                {
                    if ((new terrasur.so.so_obraMaestro(_id_urbanizacion, Profile.id_usuario)).Insertar() == false)
                    { Msg1.Text = "La entidad obraMaestro no se registró correctamente"; }
                }
                if (terrasur.so.so_estadoObra_maestro.IdEstadoObraMaestro(_id_urbanizacion) == 0)
                {
                    if ((new terrasur.so.so_estadoObra_maestro(_id_urbanizacion, new terrasur.so.so_estadoObra(0, 0, "pendiente").id_estado, Profile.id_usuario)).Insertar() == false)
                    { Msg1.Text = "El estado de obraMaestro no se registró correctamente"; }
                }
            }
            
            id_estadoobramaestro = terrasur.so.so_estadoObra_maestro.IdEstadoObraMaestro(_id_urbanizacion);
            terrasur.so.so_observacion oObj = new terrasur.so.so_observacion(id_estadoobramaestro, 0, Profile.id_usuario, txt_observacion.Text.Trim());
            if (oObj.Insertar())
            {
                Msg1.Text = "La observación se registro correctamente";
                CargarDatosActuales();
                btn_agregar.Visible = true;
                panel_observacion.Visible = false;
            }
            else { Msg1.Text = "La observación NO se registro correctamente"; }
        }
        else { Msg1.Text = "Debe introducir una observación"; }
    }

    protected string EncabezadoObservacion(object Fecha, string Estado, string Usuario)
    { return ((DateTime)Fecha).ToString("d") + " - Estado: " + Estado + " (" + Usuario + ")"; }


</script>
<asp:Label ID="lbl_id_urbanizacion" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr><td class="priTdTitle">Observaciones</td></tr>
    <%--<tr>
        <td class="formTdTitle">
            <asp:Label ID="lbl_title" runat="server" Text="Observaciones"></asp:Label>
        </td>
    </tr>--%>
    <tr><td><uc1:urbDatosView ID="urbDatosView1" runat="server" /></td></tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Panel ID="panel_observaciones" runat="server" GroupingText="Observación(es)">
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
                            <asp:ObjectDataSource ID="ods_lista_observaciones" runat="server" TypeName="terrasur.so.so_observacion" SelectMethod="ListaPorUrbanizacion">
                                <SelectParameters>
                                    <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="lbl_id_urbanizacion" PropertyName="Text" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btn_agregar" runat="server" Text="Agregar observación" OnClick="btn_agregar_Click" />
        </td>
    </tr>
    <tr>
        <td class="formTdMsg">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_observacion" runat="server" Visible="false" GroupingText="Nueva observación">
                <table>
                    <tr><td><asp:TextBox ID="txt_observacion" runat="server" TextMode="MultiLine" Width="500" Rows="3" ValidationGroup="obs"></asp:TextBox></td></tr>
                    <tr><td><asp:ValidationSummary ID="vs_obs" runat="server" ValidationGroup="obs" DisplayMode="List" /></td></tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_insertar" runat="server" Text="Guardar" CausesValidation="true" ValidationGroup="obs" OnClick="btn_insertar_Click" />
                            <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar/Volver" CausesValidation="false" OnClick="btn_cancelar_Click"/>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
