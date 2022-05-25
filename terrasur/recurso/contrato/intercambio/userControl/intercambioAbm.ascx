<%@ Control Language="C#" ClassName="intercambioAbm" %>

<script runat="server">
    private int id_intercambio { get { return int.Parse(lbl_id_intercambio.Text); } set { lbl_id_intercambio.Text = value.ToString(); } }
    private int id_contrato { get { if (MultiView1.ActiveViewIndex == 0) { return contrato.IdPorNumero(txt_num_contrato.Text.Trim()); } else { return 0; } } }
    private int id_estadolote { get { if (MultiView1.ActiveViewIndex == 1 && ddl_lote.Items.Count > 0) { return int.Parse(ddl_lote.SelectedValue); } else { return 0; } } }
    
    public void CargarInsertar()
    {
        rbl_tipo.SelectedValue = "contrato";
        lbl_id_lote.Text = "0";
        HabilitarContratoLote();
        cp_fecha.SelectedDate = DateTime.Now;
        txt_empresa.Text = "";
        txt_descripcion.Text = "";
        txt_num_contrato.Focus();
    }

    private bool VerificarInsertar()
    {
        bool correcto = true;
        if (MultiView1.ActiveViewIndex == 0)
        {
            if (id_contrato == 0)
            {
                Msg1.Text = "Debe introducir un número de contrato válido";
                correcto = false;
            }
        }
        else
        {
            if (id_estadolote == 0)
            {
                Msg1.Text = "Debe elegir un lote para el intercambio";
                correcto = false;
            }
        }
        if (cp_fecha.SelectedDate > DateTime.Now.Date)
        {
            Msg1.Text = "La fecha del intercambio no debe ser posterior a la fecha actual";
            correcto = false;
        }
        return correcto;
    }

    public bool Insertar()
    {
        if (VerificarInsertar())
        {
            intercambio iObj = new intercambio(id_contrato, id_estadolote, cp_fecha.SelectedDate, txt_empresa.Text.Trim(), txt_descripcion.Text.Trim());
            if (iObj.Insertar(Profile.id_usuario))
            {
                Msg1.Text = "El intercambio se registró correctamente";
                CargarInsertar();
                return true;
            }
            else
            {
                Msg1.Text = "El intercambio NO se registró correctamente";
                return false;
            }
        }
        else { return false; }
    }

    public void CargarActualizar(int Id_intercambio)
    {
        id_intercambio = Id_intercambio;
        intercambio iObj = new intercambio(id_intercambio);
        if (iObj.id_contrato > 0)
        {
            rbl_tipo.SelectedValue = "contrato";
            HabilitarContratoLote();
            txt_num_contrato.Text = iObj.num_contrato;
        }
        else
        {
            rbl_tipo.SelectedValue = "lote";
            HabilitarContratoLote();
            ddl_localizacion.DataBind();
            ddl_localizacion.SelectedValue = iObj.id_localizacion.ToString();
            ddl_urbanizacion.DataBind();
            ddl_urbanizacion.SelectedValue = iObj.id_urbanizacion.ToString();
            ddl_manzano.DataBind();
            ddl_manzano.SelectedValue = iObj.id_manzano.ToString();
            lbl_id_lote.Text = iObj.id_lote.ToString();
            ddl_lote.DataBind();
            if (ddl_lote.Items.FindByValue(iObj.id_estadolote.ToString()) != null) { ddl_lote.SelectedValue = iObj.id_estadolote.ToString(); }
        }
        
        cp_fecha.SelectedDate = iObj.fecha;
        txt_empresa.Text = iObj.empresa;
        txt_descripcion.Text = iObj.descripcion;
        
        txt_num_contrato.Focus();
    }

    private bool VerificarActualizar()
    {
        bool correcto = true;
        if (MultiView1.ActiveViewIndex == 0)
        {
            if (id_contrato == 0)
            {
                Msg1.Text = "Debe introducir un número de contrato válido";
                correcto = false;
            }
        }
        else
        {
            if (id_estadolote == 0)
            {
                Msg1.Text = "Debe elegir un lote para el intercambio";
                correcto = false;
            }
        }
        return correcto;
    }

    public bool Actualizar()
    {
        if (VerificarActualizar())
        {
            intercambio iObj = new intercambio(id_intercambio, id_contrato, id_estadolote, cp_fecha.SelectedDate, txt_empresa.Text.Trim(), txt_descripcion.Text.Trim());
            if (iObj.Actualizar(Profile.id_usuario))
            {
                Msg1.Text = "El intercambio se actualizó correctamente";
                return true;
            }
            else
            {
                Msg1.Text = "El intercambio NO se actualizó correctamente";
                return false;
            }
        }
        else { return false; }
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

    protected void rbl_tipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_tipo_enun.Text = rbl_tipo.SelectedItem.Text + ":";
        HabilitarContratoLote();
    }

    protected void HabilitarContratoLote()
    {
        if (rbl_tipo.SelectedValue == "contrato")
        {
            MultiView1.ActiveViewIndex = 0;
            txt_num_contrato.Text = "";
            rfv_num_contrato.Enabled = true;
            rfv_lote.Enabled = false;
        }
        else
        {
            MultiView1.ActiveViewIndex = 1;
            ddl_localizacion.DataBind();
            rfv_num_contrato.Enabled = false;
            rfv_lote.Enabled = true;
        }
    }
    
</script>
<asp:Label ID="lbl_id_intercambio" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_lote" runat="server" Text="0" Visible="false"></asp:Label>

<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_intercambio" runat="server" DisplayMode="List" ValidationGroup="intercambio" />
        </td>
    </tr>
    <tr><td class="formTdTitle" colspan="2">Datos del intercambio</td></tr>
    <tr>
        <td class="formTdEnun">Asociar al:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_tipo" runat="server" AutoPostBack="true" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbl_tipo_SelectedIndexChanged">
                <asp:ListItem Text="Contrato" Value="contrato" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Lote" Value="lote"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_tipo_enun" runat="server"></asp:Label></td>
        <td class="formTdDato">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <asp:TextBox ID="txt_num_contrato" runat="server" SkinID="txtSingleLine100" MaxLength="12"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_num_contrato" runat="server" ControlToValidate="txt_num_contrato" Display="Dynamic" ValidationGroup="intercambio" Text="*" ErrorMessage="Debe introducir el número de contrato"></asp:RequiredFieldValidator>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="formHorTdDato"><asp:DropDownList ID="ddl_localizacion" runat="server" AutoPostBack="true" DataTextField="nombre" DataValueField="id_localizacion" DataSourceID="ods_lista_localizacion" OnDataBound="ddl_localizacion_DataBound"></asp:DropDownList></td>
                            <td class="formHorTdDato"><asp:DropDownList ID="ddl_urbanizacion" runat="server" AutoPostBack="true" DataTextField="nombre" DataValueField="id_urbanizacion" DataSourceID="ods_lista_urbanizacion" OnDataBound="ddl_urbanizacion_DataBound"></asp:DropDownList></td>
                            <td class="formHorTdDato"><asp:DropDownList ID="ddl_manzano" runat="server" AutoPostBack="true" DataTextField="codigo" DataValueField="id_manzano" DataSourceID="ods_lista_manzano" OnDataBound="ddl_manzano_DataBound"></asp:DropDownList></td>
                            <td class="formHorTdDato"><asp:DropDownList ID="ddl_lote" runat="server" AutoPostBack="true" DataTextField="codigo" DataValueField="id_estadolote" DataSourceID="ods_lista_lote"></asp:DropDownList></td>
                            <td class="formHorTdDato"><asp:RequiredFieldValidator ID="rfv_lote" runat="server" Enabled="false" ControlToValidate="ddl_lote" Display="Dynamic" ValidationGroup="intercambio" Text="*" ErrorMessage="Debe elegir un lote"></asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                    <%--[id_localizacion],[nombre]--%>
                    <asp:ObjectDataSource ID="ods_lista_localizacion" runat="server" TypeName="terrasur.localizacion" SelectMethod="ListaConUrbanizacion_para_ddl">
                        <SelectParameters>
                            <asp:Parameter Name="Id_localizacion" Type="Int32" DefaultValue="0" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <%--[id_urbanizacion],[codigo],[nombre_corto],[nombre]
                        [mantenimiento_sus],[costo_m2_sus],[precio_m2_sus],[imagen],[activo]--%>
                    <asp:ObjectDataSource ID="ods_lista_urbanizacion" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista">
                        <SelectParameters>
                            <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="ddl_localizacion" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <%--[id_manzano],[codigo]--%>
                    <asp:ObjectDataSource ID="ods_lista_manzano" runat="server" TypeName="terrasur.manzano" SelectMethod="Lista_para_ddl">
                        <SelectParameters>
                            <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="ddl_urbanizacion" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <%--[id_lote],[codigo],[id_estadolote]--%>
                    <asp:ObjectDataSource ID="ods_lista_lote" runat="server" TypeName="terrasur.intercambio" SelectMethod="ListaLotesBloqueados">
                        <SelectParameters>
                            <asp:ControlParameter Name="Id_manzano" Type="Int32" ControlID="ddl_manzano" PropertyName="SelectedValue" />
                            <asp:ControlParameter Name="Id_lote" Type="Int32" ControlID="lbl_id_lote" PropertyName="Text" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </asp:View>
            </asp:MultiView>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha del intercambio:</td>
        <td class="formTdDato">
            <ew:CalendarPopup ID="cp_fecha" runat="server">
            </ew:CalendarPopup>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Empresa / Persona:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_empresa" runat="server" SkinID="txtSingleLine400"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_empresa" runat="server" ControlToValidate="txt_empresa" Display="Dynamic" ValidationGroup="intercambio" Text="*" ErrorMessage="Debe introducir la empresa o persona con quien se realizó el intercambio"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Descripción:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_descripcion" runat="server" SkinID="txtMultiLine400x4" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_descripcion" runat="server" ControlToValidate="txt_descripcion" Display="Dynamic" ValidationGroup="intercambio" Text="*" ErrorMessage="Debe introducir la descripción del intercambio"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>