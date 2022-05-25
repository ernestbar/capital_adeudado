<%@ Control Language="C#" ClassName="contratoFormLote" %>

<script runat="server">
    public event EventHandler LoteElegido;
    protected virtual void ElegirLote(object sender)
    {
        if (this.LoteElegido != null)
            this.LoteElegido(sender, new EventArgs());
    }
    public decimal tipo_cambio_actual { get { return decimal.Parse(lbl_tipo_cambio_actual.Text); } set { lbl_tipo_cambio_actual.Text = value.ToString(); } }
    public string codigo_moneda
    {
        get { return lbl_codigo_moneda.Text; }
        set
        {
            lbl_codigo_moneda.Text = value;
            if (value == "$us")
            {
                tipo_cambio_actual = 1;
                lbl_precio_total_enun.Visible = false;
                lbl_precio_total.Visible = false;
            }
            else
            {
                tipo_cambio_actual = (new tipo_cambio(DateTime.Now)).compra;
                lbl_precio_total_enun.Visible = true;
                lbl_precio_total.Visible = true;
                lbl_precio_total_enun.Text = "Precio total (" + value + "):";
            }
            CargarDatosLote();
        }
    }
    
    public int id_lote { get { if (ddl_lote.Items.Count > 0) return Int32.Parse(ddl_lote.SelectedValue); else return 0; } }
    public Decimal precio_total { get { return Decimal.Parse(lbl_precio_total.Text); } }
    public decimal costo_total { get { return decimal.Parse(lbl_costo_total.Text); } }
    private bool ver_datos_lote { get { return bool.Parse(lbl_ver_datos_lote.Text); } set { lbl_ver_datos_lote.Text = value.ToString(); } }
    public void Reset()
    {
        ver_datos_lote = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "lote", "view");
        ddl_localizacion.DataBind();
    }
    public bool Verificar()
    {
        bool correcto = true;
        if (id_lote > 0)
        {
            lote loteObj = new lote(id_lote);
            estado_lote estadoLoteObj = new estado_lote(loteObj.id_estadolote);

            if (estadoLoteObj.codigo_estado != "dis")
            {
                Msg1.Text = "El lote elegido ya no esta disponible";
                ddl_lote.DataBind();
                correcto = false;
            }
            if (loteObj.superficie_m2 == 0)
            {
                Msg1.Text = "La superficie del lote no fue definida, comuníquese con el administrador del sistema";
                correcto = false;
            }
            if (loteObj.costo_m2_sus == 0)
            {
                Msg1.Text = "El costo del lote no fue definido, comuníquese con el administrador del sistema";
                correcto = false;
            }
            if (loteObj.precio_m2_sus == 0)
            {
                Msg1.Text = "El precio del lote no fue definido, comuníquese con el administrador del sistema";
                correcto = false;
            }
        }
        else
        {
            Msg1.Text = "Debe elegir un lote";
            correcto = false;
        }
        return correcto;
    }
    
    private void CargarDatosLocalizacion()
    {
        //if (ddl_localizacion.Items.Count > 0)
        //{
        //    localizacion loc = new localizacion(Int32.Parse(ddl_localizacion.SelectedValue));
        //    if (localizacion.ImagenDireccion(loc.imagen) != ConfigurationManager.AppSettings["localizacion_dir_imagen_vacio"])
        //    {
        //        hl_localizacion.NavigateUrl = localizacion.ImagenDireccion(loc.imagen);
        //        hl_localizacion.Visible =true;
        //    }
        //    else { hl_localizacion.Visible = false; }
        //}
        //else { hl_localizacion.Visible = false; }
    }
    private void CargarDatosUrbanizacion()
    {
        //if (ddl_urbanizacion.Items.Count > 0)
        //{
        //    urbanizacion urb = new urbanizacion(Int32.Parse(ddl_urbanizacion.SelectedValue));
        //    if (urbanizacion.ImagenDireccion(urb.imagen) != ConfigurationManager.AppSettings["urbanizacion_dir_imagen_vacio"])
        //    {
        //        hl_urbanizacion.NavigateUrl = urbanizacion.ImagenDireccion(urb.imagen);
        //        hl_urbanizacion.Visible = true;
        //    }
        //    else { hl_urbanizacion.Visible = false; }
        //}
        //else { hl_urbanizacion.Visible = false; }
    }
    private void CargarDatosLote()
    {
        if (ddl_lote.Items.Count > 0)
        {
            lote loteObj = new lote(Int32.Parse(ddl_lote.SelectedValue));
            lbl_superficie.Text = loteObj.superficie_m2.ToString();
            lbl_costo_m2.Text = loteObj.costo_m2_sus.ToString("F2");
            lbl_precio_m2.Text = loteObj.precio_m2_sus.ToString("F2");
            lbl_precio_total_sus.Text = (loteObj.superficie_m2 * loteObj.precio_m2_sus).ToString("F2");
            lbl_precio_total.Text = ((loteObj.superficie_m2 * loteObj.precio_m2_sus) * tipo_cambio_actual).ToString("F2");
            lbl_costo_total.Text = ((loteObj.superficie_m2 * loteObj.costo_m2_sus) * tipo_cambio_actual).ToString();
            if (ver_datos_lote == true) ib_lote.Visible = true;
        }
        else
        {
            lbl_superficie.Text = "0";
            lbl_costo_m2.Text = "0";
            lbl_precio_m2.Text = "0";
            lbl_precio_total_sus.Text = "0";
            lbl_precio_total.Text = "0";
            lbl_costo_total.Text = "0";
            ib_lote.Visible = false;
        }
    }


    protected void ddl_localizacion_DataBound(object sender, EventArgs e)
    {
        ddl_localizacion.Items.Insert(0, new ListItem("", "0"));
        CargarDatosLocalizacion();
        ddl_urbanizacion.DataBind();
        ddl_manzano.DataBind();
        ddl_lote.DataBind();
    }
    protected void ddl_localizacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarDatosLocalizacion();
    }

    protected void ddl_urbanizacion_DataBound(object sender, EventArgs e)
    {
        CargarDatosUrbanizacion();
        ddl_manzano.DataBind();
        ddl_lote.DataBind();

    }
    protected void ddl_urbanizacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarDatosUrbanizacion();
    }

    protected void ddl_manzano_DataBound(object sender, EventArgs e)
    {
        ddl_lote.DataBind();
    }

    protected void ddl_lote_DataBound(object sender, EventArgs e)
    {
        CargarDatosLote();
        ElegirLote(sender);
    }
    protected void ddl_lote_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarDatosLote();
        ElegirLote(sender);
    }

    protected void ib_lote_Click(object sender, ImageClickEventArgs e)
    {
        Session["id_lote"] = id_lote;
        WinPopUp1.Show();
    }
</script>
<asp:Label ID="lbl_ver_datos_lote" runat="server" Text="false" Visible="false"></asp:Label>
<asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>
<asp:Label ID="lbl_tipo_cambio_actual" runat="server" Text="1" Visible="false"></asp:Label>
<asp:Label ID="lbl_costo_total" runat="server" Text="0" Visible="false"></asp:Label>

<asp:WinPopUp id="WinPopUp1" runat="server" NavigateUrl="~/recurso/inventario/lote/loteDetalle.aspx"></asp:WinPopUp>
<table class="contratoFormTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="contratoFormTdMsg" colspan="4">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="contratoFormTdHorEnun">Localizacion</td>
        <td class="contratoFormTdHorEnun">Sector</td>
        <td class="contratoFormTdHorEnun">Manzano</td>
        <td class="contratoFormTdHorEnun">Lote</td>
    </tr>
    <tr>
        <td class="contratoFormTdHorDato">
            <asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataTextField="nombre" DataValueField="id_localizacion" DataSourceID="ods_lista_localizacion" OnDataBound="ddl_localizacion_DataBound" OnSelectedIndexChanged="ddl_localizacion_SelectedIndexChanged"></asp:DropDownList>
            <%--<asp:HyperLink ID="hl_localizacion" runat="server" Text="Ver imagen" ImageUrl="~/images/gv/view.gif" Target="_blank"></asp:HyperLink>--%>
        </td>
        <td class="contratoFormTdHorDato">
            <asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataTextField="nombre" DataValueField="id_urbanizacion" DataSourceID="ods_lista_urbanizacion" OnDataBound="ddl_urbanizacion_DataBound" OnSelectedIndexChanged="ddl_urbanizacion_SelectedIndexChanged"></asp:DropDownList>
            <%--<asp:HyperLink ID="hl_urbanizacion" runat="server" Text="Ver imagen" ImageUrl="~/images/gv/view.gif" Target="_blank"></asp:HyperLink>--%>
        </td>
        <td class="contratoFormTdHorDato">
            <asp:DropDownList ID="ddl_manzano" runat="server" AutoPostBack="true" DataTextField="codigo" DataValueField="id_manzano" DataSourceID="ods_lista_manzano" OnDataBound="ddl_manzano_DataBound"></asp:DropDownList>
        </td>
        <td class="contratoFormTdHorDato">
            <asp:DropDownList ID="ddl_lote" runat="server" AutoPostBack="true" DataTextField="codigo" DataValueField="id_lote" DataSourceID="ods_lista_lote" OnDataBound="ddl_lote_DataBound" OnSelectedIndexChanged="ddl_lote_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfl_lote" runat="server" ControlToValidate="ddl_lote" Display="Dynamic" ValidationGroup="contrato" Text="*" ErrorMessage="Debe elegir un lote"></asp:RequiredFieldValidator>
            <asp:ImageButton ID="ib_lote" runat="server" ImageUrl="~/images/gv/view.gif" OnClick="ib_lote_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoFormTdEnun">Superficie (m2):</td>
                    <td class="contratoFormTdDato"><asp:Label ID="lbl_superficie" runat="server"></asp:Label></td>
                    <td class="contratoFormTdEspacio"></td>
                    <td class="contratoFormTdEnun">Costo ($/m2):</td>
                    <td class="contratoFormTdDato"><asp:Label ID="lbl_costo_m2" runat="server"></asp:Label></td>
                    <td class="contratoFormTdEspacio"></td>
                    <td class="contratoFormTdEnun">Precio ($/m2):</td>
                    <td class="contratoFormTdDato"><asp:Label ID="lbl_precio_m2" runat="server"></asp:Label></td>
                    <td class="contratoFormTdEspacio"></td>
                    <td class="contratoFormTdEnun">Precio total ($):</td>
                    <td class="contratoFormTdDato"><asp:Label ID="lbl_precio_total_sus" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td class="contratoFormTdEnun" align="right"><asp:Label ID="lbl_precio_total_enun" runat="server" Visible="false" Text="Precio total (Bs):"></asp:Label></td>
                    <td class="contratoFormTdDato" align="right"><asp:Label ID="lbl_precio_total" runat="server" Visible="false"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<%--[id_localizacion],[nombre]--%>
<asp:ObjectDataSource ID="ods_lista_localizacion" runat="server" TypeName="terrasur.localizacion" SelectMethod="ListaConUrbanizacion_para_ddl">
    <SelectParameters>
        <asp:Parameter Name="Id_localizacion" Type="Int32" DefaultValue="0" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--[id_urbanizacion],[nombre]--%>
<asp:ObjectDataSource ID="ods_lista_urbanizacion" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="ListaPorActivo_para_ddl">
    <SelectParameters>
        <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
        <asp:Parameter Name="Activo" Type="Boolean" DefaultValue="True" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--[id_manzano],[codigo]--%>
<asp:ObjectDataSource ID="ods_lista_manzano" runat="server" TypeName="terrasur.manzano" SelectMethod="Lista_para_ddl">
    <SelectParameters>
        <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" />
    </SelectParameters>
</asp:ObjectDataSource>
<%--[id_lote],[codigo]--%>
<asp:ObjectDataSource ID="ods_lista_lote" runat="server" TypeName="terrasur.lote" SelectMethod="ListaDisponible">
    <SelectParameters>
        <asp:ControlParameter Name="Id_manzano" Type="Int32" ControlID="ddl_manzano" PropertyName="SelectedValue" />
    </SelectParameters>
</asp:ObjectDataSource>