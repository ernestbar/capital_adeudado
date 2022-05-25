<%@ Control Language="C#" ClassName="bonoPromotorAbm" %>

<script runat="server">
    public void Reset()
    {
        //if (ddl_mes.Items.Count == 0) ddl_mes.DataBind();
        //if (ddl_mes.Items.Count > 0) ddl_mes.SelectedIndex = 0;

        //if (ddl_promotor.Items.Count == 0) ddl_promotor.DataBind();
        //if (ddl_promotor.Items.Count > 0) ddl_promotor.SelectedIndex = 0;

        txt_bono_mov.Text = ""; cbl_bono_mov.Checked = false; txt_bono_mov.Enabled = false; rfv_bono_mov.Enabled = false; rv_bono_mov.Enabled = false;
        txt_bono_prod_num_ventas.Text = ""; cbl_bono_prod_num_ventas.Checked = false; txt_bono_prod_num_ventas.Enabled = false; rfv_bono_prod_num_ventas.Enabled = false; rv_bono_prod_num_ventas.Enabled = false;
        txt_bono_prod_monto_ventas.Text = ""; cbl_bono_prod_monto_ventas.Checked = false; txt_bono_prod_monto_ventas.Enabled = false; rfv_bono_prod_monto_ventas.Enabled = false; rv_bono_prod_monto_ventas.Enabled = false;
        txt_bono_prod_premio.Text = ""; cbl_bono_prod_premio.Checked = false; txt_bono_prod_premio.Enabled = false; rfv_bono_prod_premio.Enabled = false; rv_bono_prod_premio.Enabled = false;
    }

    public bool Registrar()
    {
        if (cbl_bono_mov.Checked == true || cbl_bono_prod_num_ventas.Checked == true || cbl_bono_prod_monto_ventas.Checked == true || cbl_bono_prod_premio.Checked == true)
        {
            int Id_promotor = int.Parse(ddl_promotor.SelectedValue);
            DateTime Fecha = DateTime.Parse(ddl_mes.SelectedValue);
            decimal Bono_mov = -1, Bono_prod_num_ventas = -1, Bono_prod_monto_ventas = -1, Bono_prod_premio = -1;
            if (cbl_bono_mov.Checked == true) Bono_mov = decimal.Parse(txt_bono_mov.Text.Trim());
            if (cbl_bono_prod_num_ventas.Checked == true) Bono_prod_num_ventas = decimal.Parse(txt_bono_prod_num_ventas.Text.Trim());
            if (cbl_bono_prod_monto_ventas.Checked == true) Bono_prod_monto_ventas = decimal.Parse(txt_bono_prod_monto_ventas.Text.Trim());
            if (cbl_bono_prod_premio.Checked == true) Bono_prod_premio = decimal.Parse(txt_bono_prod_premio.Text.Trim());
            bono_promotor bonoObj = new bono_promotor(Id_promotor, Fecha, Bono_mov, Bono_prod_num_ventas, Bono_prod_monto_ventas, Bono_prod_premio);
            if (bonoObj.Registrar(Profile.id_usuario) == true)
            {
                Msg1.Text = "La asignación del bono se registró correctamente";
                return true;
            }
            else
            {
                Msg1.Text = "La asignación del bono NO se registró correctamente";
                return false;
            }
        }
        else
        {
            Msg1.Text = "No eligió ninguno de los bonos para ser modificado";
            return false;
        }
    }

    protected void cbl_bono_mov_CheckedChanged(object sender, EventArgs e)
    {
        txt_bono_mov.Enabled = cbl_bono_mov.Checked;
        rfv_bono_mov.Enabled = cbl_bono_mov.Checked;
        rv_bono_mov.Enabled = cbl_bono_mov.Checked;

        if (cbl_bono_mov.Checked == true)
        {
            bono_promotor bonoObj = new bono_promotor(int.Parse(ddl_promotor.SelectedValue), DateTime.Parse(ddl_mes.SelectedValue));
            if (bonoObj.id_bono > 0 && bonoObj.bono_mov >= 0) txt_bono_mov.Text = bonoObj.bono_mov.ToString().Replace('.', ',');
            else { txt_bono_mov.Text = ""; }
        }
        else { txt_bono_mov.Text = ""; }
    }
    protected void cbl_bono_prod_num_ventas_CheckedChanged(object sender, EventArgs e)
    {
        txt_bono_prod_num_ventas.Enabled = cbl_bono_prod_num_ventas.Checked;
        rfv_bono_prod_num_ventas.Enabled = cbl_bono_prod_num_ventas.Checked;
        rv_bono_prod_num_ventas.Enabled = cbl_bono_prod_num_ventas.Checked;

        if (cbl_bono_prod_num_ventas.Checked == true)
        {
            bono_promotor bonoObj = new bono_promotor(int.Parse(ddl_promotor.SelectedValue), DateTime.Parse(ddl_mes.SelectedValue));
            if (bonoObj.id_bono > 0 && bonoObj.bono_prod_num_ventas >= 0) txt_bono_prod_num_ventas.Text = bonoObj.bono_prod_num_ventas.ToString().Replace('.', ',');
            else { txt_bono_prod_num_ventas.Text = ""; }
        }
        else { txt_bono_prod_num_ventas.Text = ""; }
    }
    protected void cbl_bono_prod_monto_ventas_CheckedChanged(object sender, EventArgs e)
    {
        txt_bono_prod_monto_ventas.Enabled = cbl_bono_prod_monto_ventas.Checked;
        rfv_bono_prod_monto_ventas.Enabled = cbl_bono_prod_monto_ventas.Checked;
        rv_bono_prod_monto_ventas.Enabled = cbl_bono_prod_monto_ventas.Checked;
        
        if (cbl_bono_prod_monto_ventas.Checked == true)
        {
            bono_promotor bonoObj = new bono_promotor(int.Parse(ddl_promotor.SelectedValue), DateTime.Parse(ddl_mes.SelectedValue));
            if (bonoObj.id_bono > 0 && bonoObj.bono_prod_monto_ventas >= 0) txt_bono_prod_monto_ventas.Text = bonoObj.bono_prod_monto_ventas.ToString().Replace('.', ',');
            else { txt_bono_prod_monto_ventas.Text = ""; }
        }
        else { txt_bono_prod_monto_ventas.Text = ""; }
    }
    protected void cbl_bono_prod_premio_CheckedChanged(object sender, EventArgs e)
    {
        txt_bono_prod_premio.Enabled = cbl_bono_prod_premio.Checked;
        rfv_bono_prod_premio.Enabled = cbl_bono_prod_premio.Checked;
        rv_bono_prod_premio.Enabled = cbl_bono_prod_premio.Checked;
        if (cbl_bono_prod_premio.Checked == true)
        {
            bono_promotor bonoObj = new bono_promotor(int.Parse(ddl_promotor.SelectedValue), DateTime.Parse(ddl_mes.SelectedValue));
            if (bonoObj.id_bono > 0 && bonoObj.bono_prod_premio >= 0) txt_bono_prod_premio.Text = bonoObj.bono_prod_premio.ToString().Replace('.', ',');
            else { txt_bono_prod_premio.Text = ""; }
        }
        else { txt_bono_prod_premio.Text = ""; }
    }

</script>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_bono" runat="server" DisplayMode="List" ValidationGroup="bono" />
        </td>
    </tr>
    <tr><td class="formTdTitle" colspan="2">Asignación de bonos a promotores</td></tr>
    <tr>
        <td class="formTdEnun">Mes:</td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_mes" runat="server" DataSourceID="ods_lista_meses" DataTextField="nombre" DataValueField="fecha"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfv_mes" runat="server" ControlToValidate="ddl_mes" Display="Dynamic" ValidationGroup="bono" Text="*"></asp:RequiredFieldValidator>
            <%--[fecha],[nombre]--%>
            <asp:ObjectDataSource ID="ods_lista_meses" runat="server" TypeName="terrasur.bono_promotor" SelectMethod="ListaMeses">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Promotor:</td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_promotor" runat="server" DataSourceID="ods_lista_promotores" DataTextField="nombre_completo" DataValueField="id_usuario"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfv_promotor" runat="server" ControlToValidate="ddl_promotor" Display="Dynamic" ValidationGroup="bono" Text="*"></asp:RequiredFieldValidator>
            <%--[id_usuario],[paterno],[materno],[nombres],[nombre_completo],[ci],[nombre_usuario],[activo],[nombre_grupo]--%>
            <asp:ObjectDataSource ID="ods_lista_promotores" runat="server" TypeName="terrasur.promotor" SelectMethod="ListaNoEliminado">
                <SelectParameters><asp:Parameter Name="Id_grupoventa" Type="Int32" DefaultValue="0" /></SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Bonos:</td>
        <td class="formTdDato">
            <table cellpadding="0">
                <tr>
                    <td><asp:CheckBox ID="cbl_bono_mov" runat="server" Text="Bono de movilidad ($us):" AutoPostBack="true" OnCheckedChanged="cbl_bono_mov_CheckedChanged" /></td>
                    <td>
                        <asp:TextBox ID="txt_bono_mov" runat="server" Enabled="false" SkinID="txtSingleLine100" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_bono_mov" runat="server" Enabled="false" ControlToValidate="txt_bono_mov" Display="Dynamic" ValidationGroup="bono" Text="*" ErrorMessage="Debe introducir el monto del Bono de movilidad"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_bono_mov" runat="server" Enabled="false" ControlToValidate="txt_bono_mov" Display="Dynamic" Type="Double" MinimumValue="0" MaximumValue="99999" ValidationGroup="bono" Text="*" ErrorMessage=""></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td><asp:CheckBox ID="cbl_bono_prod_num_ventas" runat="server" Text="Bono de producción por Nº ventas ($us):" AutoPostBack="true" OnCheckedChanged="cbl_bono_prod_num_ventas_CheckedChanged" /></td>
                    <td>
                        <asp:TextBox ID="txt_bono_prod_num_ventas" runat="server" Enabled="false" SkinID="txtSingleLine100" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_bono_prod_num_ventas" runat="server" Enabled="false" ControlToValidate="txt_bono_prod_num_ventas" Display="Dynamic" ValidationGroup="bono" Text="*" ErrorMessage="Debe introducir el monto del Bono de producción por Nº ventas"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_bono_prod_num_ventas" runat="server" Enabled="false" ControlToValidate="txt_bono_prod_num_ventas" Display="Dynamic" Type="Double" MinimumValue="0" MaximumValue="99999" ValidationGroup="bono" Text="*" ErrorMessage=""></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td><asp:CheckBox ID="cbl_bono_prod_monto_ventas" runat="server" Text="Bono de producción por volumen de ventas ($us):" AutoPostBack="true" OnCheckedChanged="cbl_bono_prod_monto_ventas_CheckedChanged" /></td>
                    <td>
                        <asp:TextBox ID="txt_bono_prod_monto_ventas" runat="server" Enabled="false" SkinID="txtSingleLine100" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_bono_prod_monto_ventas" runat="server" Enabled="false" ControlToValidate="txt_bono_prod_monto_ventas" Display="Dynamic" ValidationGroup="bono" Text="*" ErrorMessage="Debe introducir el monto del Bono de producción por volumen de ventas"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_bono_prod_monto_ventas" runat="server" Enabled="false" ControlToValidate="txt_bono_prod_monto_ventas" Display="Dynamic" Type="Double" MinimumValue="0" MaximumValue="99999" ValidationGroup="bono" Text="*" ErrorMessage=""></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td><asp:CheckBox ID="cbl_bono_prod_premio" runat="server" Text="Bono de producción - Premio por ventas ($us):" AutoPostBack="true" OnCheckedChanged="cbl_bono_prod_premio_CheckedChanged" /></td>
                    <td>
                        <asp:TextBox ID="txt_bono_prod_premio" runat="server" Enabled="false" SkinID="txtSingleLine100" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_bono_prod_premio" runat="server" Enabled="false" ControlToValidate="txt_bono_prod_premio" Display="Dynamic" ValidationGroup="bono" Text="*" ErrorMessage="Debe introducir el monto del Premio por ventas"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rv_bono_prod_premio" runat="server" Enabled="false" ControlToValidate="txt_bono_prod_premio" Display="Dynamic" Type="Double" MinimumValue="0" MaximumValue="99999" ValidationGroup="bono" Text="*" ErrorMessage=""></asp:RangeValidator>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

