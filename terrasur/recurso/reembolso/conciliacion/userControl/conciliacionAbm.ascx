<%@ Control Language="C#" ClassName="conciliacionAbm" %>

<script runat="server">
    public event EventHandler Eleccion;
    protected virtual void RealizarEleccion(object sender)
    {
        if (this.Eleccion != null) this.Eleccion(sender, new EventArgs());
    }

    private string tipo { get { return "traspaso"; } }
    private int id_usuario { get { return int.Parse(lbl_id_usuario.Text); } set { lbl_id_usuario.Text = value.ToString(); } }
    private int id_motivo { get { return int.Parse(lbl_id_motivo.Text); } set { lbl_id_motivo.Text = value.ToString(); } }
    public DateTime fecha { get { return cp_fecha.SelectedDate; } }

    public int id_contrato_elegido
    {
        get { return int.Parse(lbl_id_contrato_elegido.Text); }
        set { lbl_id_contrato_elegido.Text = value.ToString(); }
    }

    public void CargarInsertar()
    {
        id_usuario = 0;
        id_motivo = 0;

        lbl_fecha_enun.Text = "F.Traspaso:";
        cp_fecha.SelectedDate = DateTime.Now;
        cp_fecha.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, tipo, "cambiar_fecha");
        btn_obtener.Enabled = true;
        txt_num_contrato.Text = "";
        txt_num_contrato.Enabled = true;
        btn_obtener.Visible = true;

        ddl_motivo.DataBind();
        ddl_motivo.Enabled = false;
        ddl_motivo.SelectedValue = "2";

        txt_num_contrato.Focus();
    }

    public bool VerificarInsertar()
    {
        bool correcto = true;

        if (!btn_obtener.Enabled)
        {
            Msg1.Text = "Usted no esta registrado como una persona válida para registrar traspasos";
            correcto = false;
        }

        if (id_contrato_elegido != contrato.IdPorNumero(txt_num_contrato.Text.Trim()))
        {
            Msg1.Text = "Debe presionar el botón \"Obtener datos\" para definir los elementos del reembolso del contrato " + txt_num_contrato.Text.Trim();
            correcto = false;
        }

        if (correcto)
        {
            if (VerificarContrato(true) == false) { correcto = false; }
        }

        // Validar que no esté revertido
        int estado_id = contrato.Estado(id_contrato_elegido, DateTime.Now);
        if (estado_id == 2) {
            Msg1.Text = "No esta permitido realizar conciliaciones a contratos Revertidos";
            correcto = false;
        }
		
        return correcto;
    }

    public bool Insertar(string Observacion, int Id_lote)
    {
        int _Id_contrato = contrato.IdPorNumero(txt_num_contrato.Text.Trim());

        terrasur.traspaso.conciliacion rObj = new terrasur.traspaso.conciliacion(_Id_contrato, Observacion, Id_lote, cp_fecha.SelectedDate);
        if (rObj.Insertar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
        {
            Msg1.Text = "El traspaso por conciliación se registró correctamente";
            return true;
        }
        else
        {
            Msg1.Text = "El traspaso por conciliación NO se registró correctamente";
            return false;
        }
    }

    private bool VerificarContrato(bool insertar)
    {
        bool correcto = true;

        //Se verifica la existencia del contrato
        int _Id_contrato = contrato.IdPorNumero(txt_num_contrato.Text.Trim());
        if (_Id_contrato == 0)
        {
            Msg1.Text = "El contrato " + txt_num_contrato.Text.Trim() + " no existe";
            correcto = false;
        }

        //Se verifica que el contrato no haya sido reembolsado previamente
        if (correcto)
        {
            int _id_reem = terrasur.traspaso.reembolso.VerificarContrato(insertar, 0, _Id_contrato);
            if (_id_reem > 0)
            {
                Msg1.Text = "El contrato " + txt_num_contrato.Text.Trim() + " ya tiene asociado un reembolso";
                correcto = false;
            }
            else if (_id_reem < 0)
            {
                Msg1.Text = "Ocurrió un error en la verificación de reembolso";
                correcto = false;
            }
        }

        return correcto;
    }

    protected void btn_obtener_Click(object sender, EventArgs e)
    {
        id_contrato_elegido = contrato.IdPorNumero(txt_num_contrato.Text.Trim());
        RealizarEleccion(this);
    }
</script>
<asp:Label ID="lbl_traspaso" runat="server" Text="true" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_usuario" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_motivo" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_contrato_elegido" runat="server" Text="0" Visible="false"></asp:Label>

<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="4">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_fecha_enun" runat="server"></asp:Label></td>
        <td class="formTdDato"><ew:CalendarPopup ID="cp_fecha" runat="server"></ew:CalendarPopup></td>
        
        <td class="formTdEnun"></td>
        <td class="formTdDato">

        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nº contrato:</td>
        <td class="formTdDato">
            <asp:Panel ID="panel_num_contrato" runat="server" DefaultButton="btn_obtener">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:TextBox ID="txt_num_contrato" runat="server" SkinID="txtSingleLine100" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_num_contrato" runat="server" ControlToValidate="txt_num_contrato" Display="Dynamic" ValidationGroup="reembolso" Text="*" ErrorMessage="Debe introducir el número de contrato"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rev_num_contrato" runat="server" ControlToValidate="txt_num_contrato" Display="Dynamic" ValidationGroup="reembolso" Text="*" ErrorMessage="El número del contrato contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:contrato_ExpReg_numero %>"></asp:RegularExpressionValidator> 
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_obtener" runat="server" Width="105" Text="Obtener datos" CausesValidation="true" ValidationGroup="reembolso" OnClick="btn_obtener_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>

        <td class="formTdEnun">Motivo:</td>
        <td class="formTdDato" valign="top">
            <asp:DropDownList ID="ddl_motivo" runat="server" DataSourceID="ods_motivo_lista" DataTextField="nombre" DataValueField="id_motivo">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfv_motivo" runat="server" ControlToValidate="ddl_motivo" Display="Dynamic" ValidationGroup="reembolso" Text="*" ErrorMessage="No existen motivos de reembolso registrados">
            </asp:RequiredFieldValidator>
            <%--[id_motivo],[nombre]--%>
            <asp:ObjectDataSource ID="ods_motivo_lista" runat="server" TypeName="terrasur.traspaso.motivo" SelectMethod="ListaParaDll">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_motivo" Type="Int32" ControlID="lbl_id_motivo" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>