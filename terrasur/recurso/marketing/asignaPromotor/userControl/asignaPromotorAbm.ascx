<%@ Control Language="C#" ClassName="asignaPromotorAbm" %>

<script runat="server">
    public int id_contrato { get { return int.Parse(lbl_id_contrato.Text); } set { lbl_id_contrato.Text = value.ToString(); Cargar(); } }
    protected int id_grupoventa { get { return int.Parse(lbl_id_grupoventa.Text); } set { lbl_id_grupoventa.Text = value.ToString(); } }
    protected int id_grupopromotor { get { return int.Parse(lbl_id_grupopromotor.Text); } set { lbl_id_grupopromotor.Text = value.ToString(); } }
    protected bool permiso_comision { get { return bool.Parse(lbl_permiso_comision.Text); } set { lbl_permiso_comision.Text = value.ToString(); } }

    protected decimal comision_pagada { get { return decimal.Parse(lbl_comision_pagada.Text); } set { lbl_comision_pagada.Text = value.ToString(); } }
    protected decimal comision_total { get { return decimal.Parse(lbl_comision_total.Text); } set { lbl_comision_total.Text = value.ToString(); } }
    protected decimal comision_porcentaje { get { return decimal.Parse(lbl_comision_porcentaje.Text); } set { lbl_comision_porcentaje.Text = value.ToString(); } }
    protected decimal comision_porcentaje_minimo { get { return decimal.Parse(lbl_comision_porcentaje_minimo.Text); } set { lbl_comision_porcentaje_minimo.Text = value.ToString(); } }

    public bool Verificar()
    {
        if (Page.IsValid == true)
        {
            bool correcto = true;
            if (txt_comision.Enabled == true)
            {
                //if (id_grupopromotor == 0 && decimal.Parse(txt_comision.Text.Trim()) == 0) { correcto = true; }
                //else
                //{
                if (decimal.Parse(txt_comision.Text.Trim()) < comision_porcentaje_minimo)
                {
                    Msg1.Text = "El porcentaje comisionado no puede ser menor a: " + comision_porcentaje_minimo.ToString("F2") + "% (comision pagada hasta el momento)";
                    correcto = false;
                }
                //}
            }
            if (int.Parse(ddl_promotor.SelectedValue) == id_grupopromotor && decimal.Parse(txt_comision.Text.Trim()) == comision_porcentaje)
            {
                Msg1.Text = "No realizó ningún cambio a la asignación";
                correcto = false;
            }
            return correcto;
        }
        else { return false; }
    }

    public bool Modificar()
    {
        bool correcto = true;
        if (int.Parse(ddl_promotor.SelectedValue) != id_grupopromotor)
        {
            asignacion_promotor ap_promotor = new asignacion_promotor(id_contrato, int.Parse(ddl_promotor.SelectedValue));
            ////if (ap_promotor.Asignar(3) == true)
            if (ap_promotor.Asignar(Profile.id_usuario) == true)
            {
                Msg1.Text = "La asignación del promotor se realizó correctamente";
            }
            else
            {
                Msg1.Text = "La asignación del promotor NO se realizó correctamente";
                correcto = false;
            }
        }
        if (correcto == true && txt_comision.Enabled == true)
        {
            //if (id_grupopromotor == 0 && decimal.Parse(txt_comision.Text.Trim()) == 0) { correcto = true; }
            //else
            //{
            asignacion_promotor ap_comision = new asignacion_promotor(id_contrato, decimal.Parse(txt_comision.Text.Trim()));
            ////if (ap_comision.ModificarPorcentaje(3) == true)
            if (ap_comision.ModificarPorcentaje(Profile.id_usuario) == true)
            {
                Msg1.Text = "El porcentaje de comisión se modificó correctamente";
            }
            else
            {
                Msg1.Text = "El porcentaje de comisión NO se modificó correctamente";
                correcto = false;
            }
            //}
        }
        return correcto;
    }

    protected void Cargar()
    {
        asignacion_promotor ap = new asignacion_promotor(id_contrato);
        comision_total = ap.comision_total;
        comision_pagada = comision_promotor.TotalComisionado(id_contrato);
        comision_porcentaje = ap.porcentaje;
        if (comision_pagada > 0)
        {
            contrato c = new contrato(id_contrato);
            comision_porcentaje_minimo = Math.Round((comision_pagada / c.precio_final) * 100, 2) + Convert.ToDecimal(0.01);
        }
        else { comision_porcentaje_minimo = 0; }

        if (ap.id_grupopromotor > 0)
        {
            grupo_promotor gp = new grupo_promotor(ap.id_grupopromotor);
            id_grupoventa = gp.id_grupoventa;
            id_grupopromotor = gp.id_grupopromotor;
        }
        else
        {
            id_grupoventa = 0;
            id_grupopromotor = 0;
        }

        permiso_comision = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "asignaPromotor", "modificar_comision");
        if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "asignaPromotor", "modificar_asignacion") == true)
        {
            ddl_grupo.Enabled = true;
            ddl_promotor.Enabled = true;
        }
        else
        {
            ddl_grupo.Enabled = false;
            ddl_promotor.Enabled = false;
        }
        
        ddl_promotor.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "asignaPromotor", "modificar_asignacion");
        gv_comisiones.Columns[1].HeaderText = "Pago del cliente(" + contrato.CodigoMoneda(id_contrato) + ")";
        gv_comisiones.DataBind();
        ddl_grupo.DataBind();
        ddl_grupo.SelectedValue = id_grupoventa.ToString();
        ddl_promotor.DataBind();
        ddl_promotor.SelectedValue = id_grupopromotor.ToString();
        HabilitarDeshabilitarPorcentaje();
    }
    
    protected void ddl_grupo_DataBound(object sender, EventArgs e)
    {
        ddl_grupo.Items.Insert(0, new ListItem("-------", "0"));
    }

    protected void ddl_promotor_DataBound(object sender, EventArgs e)
    {
        ddl_promotor.Items.Insert(0, new ListItem("Ninguno", "0"));
        HabilitarDeshabilitarPorcentaje();
    }

    protected void ddl_promotor_SelectedIndexChanged(object sender, EventArgs e)
    {
        HabilitarDeshabilitarPorcentaje();
    }
    protected void HabilitarDeshabilitarPorcentaje()
    {
        if (permiso_comision == true) txt_comision.Enabled = ddl_promotor.SelectedValue.Equals("0").Equals(false);
        else txt_comision.Enabled = false;
        if (ddl_promotor.SelectedValue == "0") { txt_comision.Text = comision_porcentaje.ToString(); }
    }
    
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_grupoventa" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_grupopromotor" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_permiso_comision" runat="server" Text="false" Visible="false"></asp:Label>

<asp:Label ID="lbl_comision_pagada" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_comision_total" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_comision_porcentaje" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_comision_porcentaje_minimo" runat="server" Text="0" Visible="false"></asp:Label>

<asp:Msg ID="Msg1" runat="server"></asp:Msg>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formHorTdEnun" valign="bottom">Promotor:</td>
        <td class="formHorTdDato" align="left">
            <table>
                <tr>
                    <td class="formHorTdEnun">Grupo de venta</td>
                    <td class="formHorTdEnun">Promotor</td>
                </tr>
                <tr>
                    <td class="formHorTdDato"><asp:DropDownList ID="ddl_grupo" runat="server" DataTextField="nombre" DataValueField="id_grupoventa" DataSourceID="ods_lista_grupo" AutoPostBack="true" OnDataBound="ddl_grupo_DataBound"></asp:DropDownList></td>
                    <td class="formHorTdDato"><asp:DropDownList ID="ddl_promotor" runat="server" DataTextField="nombre_completo" DataValueField="id_grupopromotor" DataSourceID="ods_lista_promotor" AutoPostBack="true" OnDataBound="ddl_promotor_DataBound" OnSelectedIndexChanged="ddl_promotor_SelectedIndexChanged"></asp:DropDownList></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">% Comisión:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_comision" runat="server" SkinID="txtSingleLine100" MaxLength="5" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_comision" runat="server" ControlToValidate="txt_comision" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Debe introducir el porcentaje de comisión" ValidationGroup="asignacion"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rv_comision" runat="server" ControlToValidate="txt_comision" Type="Double" MinimumValue="0" MaximumValue="99" Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="El porcentaje de comisión debe estar 0 y 99" ValidationGroup="asignacion"></asp:RangeValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Comisiones pagadas:</td>
        <td class="formTdDato">
            <asp:GridView ID="gv_comisiones" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_comision">
                <Columns>
                    <asp:BoundField HeaderText="Comisión($us)" DataField="monto" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Pago del cliente($us)" DataField="monto_pago" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Fecha del pago" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField HeaderText="Tipo de pago" DataField="tipo_pago"/>
                </Columns>
                <EmptyDataTemplate>No se pagaron comisiones en este contrato</EmptyDataTemplate>
            </asp:GridView>
            <%--[id_grupopromotor],[id_usuario],[numero],[monto],[fecha],[monto_pago],[tipo_pago],[promotor]--%>
            <asp:ObjectDataSource ID="ods_lista_comision" runat="server" TypeName="terrasur.comision_promotor" SelectMethod="ListaPorContrato">
                <SelectParameters><asp:ControlParameter Name="Id_contrato" Type="Int32" ControlID="lbl_id_contrato" PropertyName="Text" /></SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>
<%--[id_grupoventa],[id_director],[nombre],[num_promotor_activo],[nombre_director]--%>
<asp:ObjectDataSource ID="ods_lista_grupo" runat="server" TypeName="terrasur.grupo_venta" SelectMethod="ListaActivoConPromotor">
    <SelectParameters>
        <asp:ControlParameter Name="Id_grupoventa" Type="Int32" ControlID="lbl_id_grupoventa" PropertyName="Text" DefaultValue="0" /> 
    </SelectParameters>
</asp:ObjectDataSource>
<%--[id_grupopromotor],[id_usuario],[nombre_completo],[ci]--%>
<asp:ObjectDataSource ID="ods_lista_promotor" runat="server" TypeName="terrasur.promotor" SelectMethod="ListaActivoPorGrupo">
    <SelectParameters>
        <asp:ControlParameter Name="Id_grupoventa" Type="Int32" ControlID="ddl_grupo" PropertyName="SelectedValue" DefaultValue="0" />
        <asp:ControlParameter Name="Id_grupopromotor" Type="Int32" ControlID="lbl_id_grupopromotor" PropertyName="Text" DefaultValue="0" /> 
    </SelectParameters>
</asp:ObjectDataSource>