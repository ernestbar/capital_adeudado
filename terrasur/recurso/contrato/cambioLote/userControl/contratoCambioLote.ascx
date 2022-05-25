<%@ Control Language="C#" ClassName="contratoCambioLote" %>

<script runat="server">
    public int id_contrato
    {
        get { return int.Parse(lbl_id_contrato.Text); }
        set
        {
            lbl_id_contrato.Text = value.ToString();
            RecuperarDatos();
        }
    }
    public int id_lote_nuevo { get { return int.Parse(lbl_id_lote_nuevo.Text); } set { lbl_id_lote_nuevo.Text = value.ToString(); } }
    protected int id_lote_actual { get { return int.Parse(lbl_id_lote_actual.Text); } set { lbl_id_lote_actual.Text = value.ToString(); } }
    protected decimal descuento_porcentaje { get { return decimal.Parse(lbl_actual_desc_por.Text); } }
    protected decimal descuento_efectivo { get { return decimal.Parse(lbl_actual_desc_sus.Text); } }
    protected decimal cuota_inicial { get { return decimal.Parse(lbl_cuota_inicial.Text); } set { lbl_cuota_inicial.Text = value.ToString(); } }
    protected decimal precio_final { get { return decimal.Parse(lbl_precio_final.Text); } set { lbl_precio_final.Text = value.ToString(); } }

    protected string codigo_moneda { get { return lbl_codigo_moneda.Text; } set { lbl_codigo_moneda.Text = value; } }
    
    protected void RecuperarDatos()
    {
        contrato_venta cv = new contrato_venta(id_contrato);
        id_lote_actual = cv.id_lote;
        lbl_actual_loc.Text = cv.localizacion_nombre;
        lbl_actual_urb.Text = cv.urbanizacion_nombre;
        lbl_actual_man.Text = cv.manzano_codigo;
        lbl_actual_lot.Text = cv.lote_codigo;
        lbl_actual_sup.Text = cv.superficie_m2.ToString();
        lbl_actual_precio_m2.Text = cv.precio_m2_sus.ToString();

        codigo_moneda = new moneda(cv.id_moneda).codigo;
        
        lbl_actual_precio.Text = cv.precio.ToString();
        lbl_actual_desc_por.Text = cv.descuento_porcentaje.ToString();
        lbl_actual_desc_sus.Text = cv.descuento_efectivo.ToString();
        lbl_actual_precio_final.Text = cv.precio_final.ToString();
        lbl_actual_cuota_inicial.Text = cv.cuota_inicial.ToString();
        cuota_inicial = cv.cuota_inicial;

        lbl_actual_precio_enun.Text = "Precio(" + codigo_moneda + ")";
        lbl_actual_desc_sus_enun.Text = "Desc.(" + codigo_moneda + ")";
        lbl_actual_precio_final_enun.Text = "Precio Final(" + codigo_moneda + ")";
        lbl_actual_cuota_inicial_enun.Text = "Cuota inicial(" + codigo_moneda + ")";
        lbl_nuevo_precio_enun.Text = "Precio(" + codigo_moneda + ")";
        lbl_nuevo_desc_sus_enun.Text = "Desc.(" + codigo_moneda + ")";
        lbl_nuevo_precio_final_enun.Text = "Precio Final(" + codigo_moneda + ")";
        lbl_nuevo_cuota_inicial_enun.Text = "Cuota inicial(" + codigo_moneda + ")";
        
        id_lote_nuevo = 0;
        ddl_localizacion.DataBind();

        
        
        
        lbl_nuevo_desc_por.Text = cv.descuento_porcentaje.ToString();
        lbl_nuevo_desc_sus.Text = cv.descuento_efectivo.ToString();
        lbl_nuevo_cuota_inicial.Text = cv.cuota_inicial.ToString();
    }

    protected void ddl_localizacion_DataBound(object sender, EventArgs e)
    {
        ddl_urbanizacion.DataBind();
        ddl_manzano.DataBind();
        ddl_lote.DataBind();
    }

    protected void ddl_urbanizacion_DataBound(object sender, EventArgs e)
    {
        ddl_manzano.DataBind();
        ddl_lote.DataBind();
    }

    protected void ddl_manzano_DataBound(object sender, EventArgs e)
    {
        ddl_lote.DataBind();
    }

    protected void ddl_lote_DataBound(object sender, EventArgs e)
    {
        CargarDatosLote();
    }

    protected void ddl_lote_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarDatosLote();
    }

    private void CargarDatosLote()
    {
        if (ddl_lote.Items.Count > 0)
        {
            if (int.Parse(ddl_lote.SelectedValue) != id_lote_nuevo)
            {
                id_lote_nuevo = int.Parse(ddl_lote.SelectedValue);
                lote lotObj = new lote(id_lote_nuevo);

                decimal tipo_cambio_actual = 1;
                if (codigo_moneda != "$us")
                {
                    DateTime fecha_registro_contrato = new contrato(id_contrato).fecha;
                    tipo_cambio_actual = (new tipo_cambio(fecha_registro_contrato)).compra;
                }
                
                decimal nuevo_precio = Math.Round((lotObj.superficie_m2 * lotObj.precio_m2_sus * tipo_cambio_actual), 0);
                decimal nuevo_precio_final = Math.Round((nuevo_precio * (1 - (descuento_porcentaje / 100))) - descuento_efectivo, 0);
                lbl_nuevo_sup.Text = lotObj.superficie_m2.ToString();
                lbl_nuevo_precio_m2.Text = lotObj.precio_m2_sus.ToString();
                lbl_nuevo_precio.Text = nuevo_precio.ToString();
                lbl_nuevo_precio_final.Text = nuevo_precio_final.ToString();

                precio_final = nuevo_precio_final;
                bool aux = Verificar();
            }
        }
        else
        {
            id_lote_nuevo = 0;
            lbl_nuevo_sup.Text = "0";
            lbl_nuevo_precio_m2.Text = "0";
            lbl_nuevo_precio.Text = "0";
            lbl_nuevo_precio_final.Text = "0";
        }
    }

    public bool Verificar()
    {
        bool correcto = true;
        if (id_lote_nuevo > 0)
        {
            if (id_lote_nuevo != id_lote_actual)
            {
                if (estado_lote.VerificarDisponible(id_lote_nuevo) == false)
                {
                    Msg1.Text = "El lote elegido ya no esta disponible";
                    ddl_lote.DataBind();
                    correcto = false;
                }
                lote lotObj = new lote(id_lote_nuevo);
                if (lotObj.superficie_m2 == 0)
                {
                    Msg1.Text = "La superficie del lote no fue definida";
                    correcto = false;
                }
                if (lotObj.costo_m2_sus == 0)
                {
                    Msg1.Text = "El costo del lote no fue definido";
                    correcto = false;
                }
                if (lotObj.precio_m2_sus == 0)
                {
                    Msg1.Text = "El precio del lote no fue definido";
                    correcto = false;
                }
                if (correcto == true)
                {
                    negocio_lote neg_lote = new negocio_lote(lotObj.id_negociolote);
                    negocio_contrato neg_contrato = new negocio_contrato(new contrato(id_contrato).id_negociocontrato);
                    if (neg_lote.id_negocio == neg_contrato.id_negocio)
                    {
                        if (precio_final < cuota_inicial)
                        {
                            Msg1.Text = "No es posible cambiar el lote porque el precio final es menor a la cuota inicial del contrato";
                            correcto = false;
                        }
                    }
                    else
                    {
                        Msg1.Text = "No se puede realizar el cambio debido a que el Negocio al cual pertenece el Contrato (" + neg_contrato.negocio_nombre + ") es diferencte al Negocio al cual pertenece el Nuevo Lote (" + neg_lote.negocio_nombre + ")";
                        correcto = false;
                    }
                }
            }
            else
            {
                Msg1.Text = "Debe elegir un lote diferente al actual"; 
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
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_lote_actual" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_lote_nuevo" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_cuota_inicial" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_precio_final" runat="server" Text="0" Visible="false"></asp:Label>

<asp:Label ID="lbl_codigo_moneda" runat="server" Text="$us" Visible="false"></asp:Label>
<table align="center">
    <tr>
        <td>
            <asp:Panel ID="panel_lote" runat="server" GroupingText="Lote del contrato">
                <table class="formHorTable">
                    <tr>
                        <td class="formHorTdMsg" colspan="8">
                            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                            <asp:ValidationSummary ID="vs_contrato_lote" runat="server" DisplayMode="List" ValidationGroup="contrato_lote" />
                        </td>
                    </tr>
                    <tr>
                        <td class="formHorTdEnun1">Lote actual:</td>
                        <td colspan="7" align="left">
                            <table>
                                <tr>
                                    <td class="formHorTdEnun">Localización</td>
                                    <td class="formHorTdEnun">Sector</td>
                                    <td class="formHorTdEnun">Manzano</td>
                                    <td class="formHorTdEnun">Lote</td>
                                </tr>
                                <tr>
                                    <td class="formHorTdDato"><asp:Label ID="lbl_actual_loc" runat="server"></asp:Label></td>
                                    <td class="formHorTdDato"><asp:Label ID="lbl_actual_urb" runat="server"></asp:Label></td>
                                    <td class="formHorTdDato"><asp:Label ID="lbl_actual_man" runat="server"></asp:Label></td>
                                    <td class="formHorTdDato"><asp:Label ID="lbl_actual_lot" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="formHorTdEnun">Superficie(m2)</td>
                        <td class="formHorTdEnun">Precio($/m2)</td>
                        <td class="formHorTdEnun"><asp:Label ID="lbl_actual_precio_enun" runat="server" Text="Precio($)"></asp:Label></td>
                        <td class="formHorTdEnun">Desc.(%)</td>
                        <td class="formHorTdEnun"><asp:Label ID="lbl_actual_desc_sus_enun" runat="server" Text="Desc.($)"></asp:Label></td>
                        <td class="formHorTdEnun"><asp:Label ID="lbl_actual_precio_final_enun" runat="server" Text="Precio Final($)"></asp:Label></td>
                        <td class="formHorTdEnun"><asp:Label ID="lbl_actual_cuota_inicial_enun" runat="server" Text="Cuota inicial($)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="formHorTdDato"><asp:Label ID="lbl_actual_sup" runat="server"></asp:Label></td>
                        <td class="formHorTdDato"><asp:Label ID="lbl_actual_precio_m2" runat="server"></asp:Label></td>
                        <td class="formHorTdDato"><asp:Label ID="lbl_actual_precio" runat="server"></asp:Label></td>
                        <td class="formHorTdDato"><asp:Label ID="lbl_actual_desc_por" runat="server"></asp:Label></td>
                        <td class="formHorTdDato"><asp:Label ID="lbl_actual_desc_sus" runat="server"></asp:Label></td>
                        <td class="formHorTdDato"><asp:Label ID="lbl_actual_precio_final" runat="server"></asp:Label></td>
                        <td class="formHorTdDato"><asp:Label ID="lbl_actual_cuota_inicial" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="formHorTdEnun1">Nuevo lote:</td>
                        <td colspan="7" align="left">
                            <table>
                                <tr>
                                    <td class="formHorTdEnun">Localización</td>
                                    <td class="formHorTdEnun">Sector</td>
                                    <td class="formHorTdEnun">Manzano</td>
                                    <td class="formHorTdEnun">Lote</td>
                                </tr>
                                <tr>
                                    <td class="formHorTdDato"><asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataTextField="nombre" DataValueField="id_localizacion" DataSourceID="ods_lista_localizacion" OnDataBound="ddl_localizacion_DataBound"></asp:DropDownList></td>
                                    <td class="formHorTdDato"><asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataTextField="nombre" DataValueField="id_urbanizacion" DataSourceID="ods_lista_urbanizacion" OnDataBound="ddl_urbanizacion_DataBound"></asp:DropDownList></td>
                                    <td class="formHorTdDato"><asp:DropDownList ID="ddl_manzano" runat="server" AutoPostBack="true" DataTextField="codigo" DataValueField="id_manzano" DataSourceID="ods_lista_manzano" OnDataBound="ddl_manzano_DataBound"></asp:DropDownList></td>
                                    <td class="formHorTdDato">
                                        <asp:DropDownList ID="ddl_lote" runat="server" AutoPostBack="true" DataTextField="codigo" DataValueField="id_lote" DataSourceID="ods_lista_lote" OnDataBound="ddl_lote_DataBound" OnSelectedIndexChanged="ddl_lote_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfv_lote" runat="server" ControlToValidate="ddl_lote" Display="Dynamic" ValidationGroup="contrato_lote" Text="*" ErrorMessage="Debe elegir un lote"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="formHorTdEnun">Superficie(m2)</td>
                        <td class="formHorTdEnun">Precio($/m2)</td>
                        <td class="formHorTdEnun"><asp:Label ID="lbl_nuevo_precio_enun" runat="server" Text="Precio($)"></asp:Label></td>
                        <td class="formHorTdEnun">Desc.(%)</td>
                        <td class="formHorTdEnun"><asp:Label ID="lbl_nuevo_desc_sus_enun" runat="server" Text="Desc.($)"></asp:Label></td>
                        <td class="formHorTdEnun"><asp:Label ID="lbl_nuevo_precio_final_enun" runat="server" Text="Precio Final($)"></asp:Label></td>
                        <td class="formHorTdEnun"><asp:Label ID="lbl_nuevo_cuota_inicial_enun" runat="server" Text="Cuota inicial($)"></asp:Label></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="formHorTdDato"><asp:Label ID="lbl_nuevo_sup" runat="server"></asp:Label></td>
                        <td class="formHorTdDato"><asp:Label ID="lbl_nuevo_precio_m2" runat="server"></asp:Label></td>
                        <td class="formHorTdDato"><asp:Label ID="lbl_nuevo_precio" runat="server"></asp:Label></td>
                        <td class="formHorTdDato"><asp:Label ID="lbl_nuevo_desc_por" runat="server"></asp:Label></td>
                        <td class="formHorTdDato"><asp:Label ID="lbl_nuevo_desc_sus" runat="server"></asp:Label></td>
                        <td class="formHorTdDato"><asp:Label ID="lbl_nuevo_precio_final" runat="server"></asp:Label></td>
                        <td class="formHorTdDato"><asp:Label ID="lbl_nuevo_cuota_inicial" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </asp:Panel>
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