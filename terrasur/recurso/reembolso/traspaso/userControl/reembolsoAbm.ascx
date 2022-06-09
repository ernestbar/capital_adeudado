<%@ Control Language="C#" ClassName="reembolsoAbm" %>

<script runat="server">
    public event EventHandler Eleccion;
    protected virtual void RealizarEleccion(object sender)
    {
        if (this.Eleccion != null) this.Eleccion(sender, new EventArgs());
    }
    
    private bool traspaso { get { return bool.Parse(lbl_traspaso.Text); } set { lbl_traspaso.Text = value.ToString(); } }
    private string tipo { get { if (traspaso) { return "traspaso"; } else { return "devolucion"; } } }
    //private bool insertar { get { return bool.Parse(lbl_insertar.Text); } set { lbl_insertar.Text = value.ToString(); } }

    private int id_reembolso { get { return int.Parse(lbl_id_reembolso.Text); } set { lbl_id_reembolso.Text = value.ToString(); } }
    private int id_usuario { get { return int.Parse(lbl_id_usuario.Text); } set { lbl_id_usuario.Text = value.ToString(); } }
    private int id_motivo { get { return int.Parse(lbl_id_motivo.Text); } set { lbl_id_motivo.Text = value.ToString(); } }
    public int id_reembolso_registrado { get { return int.Parse(lbl_id_reembolso_registrado.Text); } set { lbl_id_reembolso_registrado.Text = value.ToString(); } }
    
    public DateTime fecha { get { return cp_fecha.SelectedDate; } }
    public int id_contrato_elegido
    {
        get { return int.Parse(lbl_id_contrato_elegido.Text); }
        set { lbl_id_contrato_elegido.Text = value.ToString(); }
    }
    
    
    public void CargarInsertar(bool Traspaso)
    {
        traspaso = Traspaso;
        id_reembolso = 0;
        id_usuario = 0;
        id_motivo = 0;

        if (traspaso) { lbl_fecha_enun.Text = "F.Traspaso:"; } else { lbl_fecha_enun.Text = "F.Devolución:"; }
        cp_fecha.SelectedDate = DateTime.Now;
        cp_fecha.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, tipo, "cambiar_fecha");
        
        ddl_usuario.DataBind();
        btn_obtener.Enabled = true;
        if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, tipo, "otros_usuarios"))
        {
            ddl_usuario.Enabled = true;
        }
        else
        {
            ddl_usuario.Enabled = false;

            if (terrasur.traspaso.usuario_reembolso.Verificar(Profile.id_usuario)
                && ddl_usuario.Items.FindByValue(Profile.id_usuario.ToString()) != null)
            {
                ddl_usuario.SelectedValue = Profile.id_usuario.ToString();
            }
            else
            {
                if (ddl_usuario.Items.FindByValue("0") == null) { ddl_usuario.Items.Insert(0, new ListItem("", "0")); }
                ddl_usuario.SelectedValue = "0";
                btn_obtener.Enabled = false;
            }
        }

        txt_num_contrato.Text = "";
        txt_num_contrato.Enabled = true;
        btn_obtener.Visible = true;
        
        ddl_motivo.DataBind();

        txt_num_contrato.Focus();
    }

    public bool VerificarInsertar()
    {
        bool correcto = true;

        if (!btn_obtener.Enabled)
        {
            if (traspaso) { Msg1.Text = "Usted no esta registrado como una persona válida para registrar traspasos"; }
            else { Msg1.Text = "Usted no esta registrado como una persona válida para registrar devoluciones"; }
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
        
        return correcto;
    }

    public bool Insertar(decimal Monto, string Observacion)
    {
        //if (VerificarInsertar())
        //{
        int _Id_contrato = contrato.IdPorNumero(txt_num_contrato.Text.Trim());
        int id_moneda = new moneda(contrato.CodigoMoneda(_Id_contrato)).id_moneda;

        terrasur.traspaso.reembolso rObj = new terrasur.traspaso.reembolso(int.Parse(ddl_motivo.SelectedValue), _Id_contrato, id_moneda, int.Parse(ddl_usuario.SelectedValue), traspaso, cp_fecha.SelectedDate, Monto, Observacion);
        if (rObj.Insertar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
        {
            if (traspaso) { Msg1.Text = "El traspaso se registró correctamente"; } else { Msg1.Text = "La devolución se registró correctamente"; }
            id_reembolso_registrado = rObj.id_reembolso;
            return true;
        }
        else
        {
            if (traspaso) { Msg1.Text = "El traspaso NO se registró correctamente"; } else { Msg1.Text = "La devolución NO se registró correctamente"; }
            return false;
        }
        //}
        //else { return false; }
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
            int _id_reem = terrasur.traspaso.reembolso.VerificarContrato(insertar, id_reembolso, _Id_contrato);
            if (_id_reem <0)
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
        
        
        string _Tipo_reembolso = "traspaso"; if (!traspaso) { _Tipo_reembolso = "devolución"; }
        //Se verifica que la fecha del reembolso sea coherente
        if (correcto)
        {
            int _Estado = (-1);
            DateTime _Fecha_ultimo_pago = DateTime.Now;
            DateTime _Fecha_reversion = DateTime.Now;
            terrasur.traspaso.reembolso.VerificarFechasContrato(_Id_contrato, ref _Estado, ref _Fecha_ultimo_pago, ref _Fecha_reversion);

            ////Se verifica que el contrato esté revertido
            //if (_Estado != 2)
            //{
            //    Msg1.Text = "El contrato " + txt_num_contrato.Text.Trim() + " NO se encuentra revertido, debe revertir el contrato antes de registrar el reembolso";
            //    correcto = false;
            //}

            //Se verifica que la fecha no sea posterior a la actual
            if (cp_fecha.SelectedDate.Date > DateTime.Now.Date)
            {
                Msg1.Text = "La fecha de " + _Tipo_reembolso + " (" + cp_fecha.SelectedDate.ToString("d") + ") no puede ser posterior a la fecha actual (" + DateTime.Now.Date.ToString("d") + ")";
                correcto = false;
            }

            //Se verifica que la fecha de reembolso sea consistente con la fecha de (último pago / reversión)
            if (correcto)
            {
                if (_Estado == 1)
                {
                    if (cp_fecha.SelectedDate.Date < _Fecha_ultimo_pago.Date)
                    {
                        Msg1.Text = "La fecha de " + _Tipo_reembolso + " (" + cp_fecha.SelectedDate.ToString("d") + ") no puede ser anterior a la fecha de último pago (" + _Fecha_ultimo_pago.ToString("d") + ")";
                        correcto = false;
                    }

                    if (correcto == true && insertar == true && _Fecha_ultimo_pago.Date <= DateTime.Parse(ConfigurationManager.AppSettings["reembolso_fecha_corte"]))
                    { Msg1.Text = "DEBE VERIFICAR (EN EL FILE DEL CONTRATO) QUE NO SE HAYA REALIZADO NINGÚN TRASPASO O DEVOLUCIÓN"; }
                }
                else if (_Estado == 2)
                {
                    if (cp_fecha.SelectedDate.Date < _Fecha_reversion.Date)
                    {
                        Msg1.Text = "La fecha de " + _Tipo_reembolso + " (" + cp_fecha.SelectedDate.ToString("d") + ") no puede ser anterior a la fecha de reversión (" + _Fecha_reversion.ToString("d") + ")";
                        correcto = false;
                    }

                    if (correcto == true && insertar == true && _Fecha_reversion.Date <= DateTime.Parse(ConfigurationManager.AppSettings["reembolso_fecha_corte"]))
                    { Msg1.Text = "DEBE VERIFICAR (EN EL FILE DEL CONTRATO) QUE NO SE HAYA REALIZADO NINGÚN TRASPASO O DEVOLUCIÓN"; }
                }
                else { correcto = false; }
            }
        }
        

        return correcto;
    }

    
    public void CargarActualizar(ref terrasur.traspaso.reembolso reObj)
    {
        traspaso = reObj.traspaso;
        id_reembolso = reObj.id_reembolso;
        id_usuario = reObj.id_usuario;
        id_motivo = reObj.id_motivo;

        if (traspaso) { lbl_fecha_enun.Text = "F.Traspaso:"; } else { lbl_fecha_enun.Text = "F.Devolución:"; }
        cp_fecha.SelectedDate = reObj.fecha;
        //cp_fecha.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, tipo, "cambiar_fecha");
        cp_fecha.Enabled = false;

        ddl_usuario.DataBind();
        ddl_usuario.SelectedValue = reObj.id_usuario.ToString();
        btn_obtener.Enabled = true;
        ddl_usuario.Enabled = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, tipo, "otros_usuarios");
        

        txt_num_contrato.Text = reObj.num_contrato;
        txt_num_contrato.Enabled = false;
        btn_obtener.Visible = false;
        
        ddl_motivo.DataBind();
        ddl_motivo.SelectedValue = reObj.id_motivo.ToString();

        txt_num_contrato.Focus();
    }

    public bool VerificarActualizar()
    {
        bool correcto = true;

        if (VerificarContrato(false) == false) { correcto = false; }

        return correcto;
    }

    public bool Actualizar(string Observacion)
    {
        //if (VerificarInsertar())
        //{
        int _Id_contrato = contrato.IdPorNumero(txt_num_contrato.Text.Trim());
        int id_moneda = new moneda(contrato.CodigoMoneda(_Id_contrato)).id_moneda;

        //terrasur.traspaso.reembolso rObj = new terrasur.traspaso.reembolso(id_reembolso, int.Parse(ddl_motivo.SelectedValue), _Id_contrato, id_moneda, int.Parse(ddl_usuario.SelectedValue), traspaso, cp_fecha.SelectedDate, Monto, Observacion);
        terrasur.traspaso.reembolso rObj = new terrasur.traspaso.reembolso(id_reembolso);
        rObj.id_motivo = int.Parse(ddl_motivo.SelectedValue);
        rObj.id_usuario = int.Parse(ddl_usuario.SelectedValue);
        rObj.observacion = Observacion;
            
        if (rObj.Actualizar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host))
        {
            if (traspaso) { Msg1.Text = "El traspaso se actualizó correctamente"; } else { Msg1.Text = "La devolución se actualizó correctamente"; }
            return true;
        }
        else
        {
            if (traspaso) { Msg1.Text = "El traspaso NO se actualizó correctamente"; } else { Msg1.Text = "La devolución NO se actualizó correctamente"; }
            return false;
        }
        //}
        //else { return false; }
    }

    protected void btn_obtener_Click(object sender, EventArgs e)
    {
        id_contrato_elegido = contrato.IdPorNumero(txt_num_contrato.Text.Trim());
        RealizarEleccion(this);
    }
</script>
<asp:Label ID="lbl_traspaso" runat="server" Text="true" Visible="false"></asp:Label>
<%--<asp:Label ID="lbl_insertar" runat="server" Text="true" Visible="false"></asp:Label>--%>
<asp:Label ID="lbl_id_reembolso" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_usuario" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_motivo" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_reembolso_registrado" runat="server" Text="0" Visible="false"></asp:Label>
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
        
        <td class="formTdEnun">Procesado por:</td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_usuario" runat="server" DataSourceID="ods_usuario_lista" DataTextField="nombre" DataValueField="id_usuario">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfv_usuario" runat="server" ControlToValidate="ddl_usuario" Display="Dynamic" ValidationGroup="reembolso" Text="*" ErrorMessage="No existen usuarios registrados para procesar reembolsos">
            </asp:RequiredFieldValidator>
            <%--[id_usuario],[ci],[nombre]--%>
            <asp:ObjectDataSource ID="ods_usuario_lista" runat="server" TypeName="terrasur.traspaso.usuario_reembolso" SelectMethod="Lista">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_usuario" Type="Int32" ControlID="lbl_id_usuario" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
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