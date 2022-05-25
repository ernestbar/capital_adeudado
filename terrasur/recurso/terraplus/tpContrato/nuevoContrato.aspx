<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Registro de contratos TerraPlus" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpContratoBusqueda.ascx" tagname="tpContratoBusqueda" tagprefix="uc2" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpDatosTerraPlus.ascx" tagname="tpDatosTerraPlus" tagprefix="uc3" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpContratoAbm.ascx" tagname="tpContratoAbm" tagprefix="uc4" %>

<script runat="server">
    private int id_cliente { get { return int.Parse(lbl_id_cliente.Text); } set { lbl_id_cliente.Text = value.ToString(); } }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        this.tpContratoBusqueda1.Eleccion += new EventHandler(busqueda_realizada);
        
        if (!Page.IsPostBack)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpContrato", "insert")) { tpContratoBusqueda1.Reset(); }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    protected void busqueda_realizada(object sender, System.EventArgs e)
    {
        int id_contrato_terraplus = tpContratoBusqueda1.id_resultado;
        id_cliente = tpContratoBusqueda1.id_cliente_terraplus;

        /*if (id_contrato_terraplus == 0)
        {
            MultiView1.ActiveViewIndex = 1;
            tpDatosTerraPlus1.id_cliente = id_cliente;

            panel_registro.Visible = true;
            tpContratoAbm1.CargarInsertar(id_cliente);
        }
        else
        {*/
        int p_id_contrato_terraplus_vigente = terrasur.terraplus.tp_contrato.IdContratoPorCliente(id_cliente);
        if (p_id_contrato_terraplus_vigente == 0)
        {
            if (terrasur.terraplus.tp_contrato.VerificarClienteTitularLote(id_cliente))
            {
                MultiView1.ActiveViewIndex = 1;
                tpDatosTerraPlus1.id_cliente = id_cliente;

                panel_registro.Visible = true;
                tpContratoAbm1.CargarInsertar(id_cliente);
            }
            else { Msg1.Text = "El cliente elegido no es titular de ningún contrato de BBR"; }
        }
        else { Msg1.Text = "El cliente ya tiene un contrato TerraPlus activo"; }
        /*}*/
    }
    
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        tpContratoBusqueda1.Reset();
    }

    protected void btn_insertar_Click(object sender, EventArgs e)
    {
        if (tpContratoAbm1.Insertar())
        {
            tpDatosTerraPlus1.id_cliente = id_cliente;
            panel_registro.Visible = false;
        }
    }
    


</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="tpContrato" MostrarLink="false" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
    <asp:Label runat="server" id="lbl_id_cliente" Visible="false" Text="0"/>
    <table class="priTable">
        <tr><td class="priTdTitle">Registro de contratos TerraPlus</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdBusqueda">
                                    <uc2:tpContratoBusqueda ID="tpContratoBusqueda1" runat="server" buscar_contrato="false" responder_si_el_cliente_no_tiene_contrato="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="tdMsg">
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table align="center">
                            <tr>
                                <td>
                                    <asp:Panel ID="panel_cambio" runat="server" DefaultButton="btn_insertar">
                                        <table class="tableContenido" align="center">
                                            <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro cliente" SkinID="btnVolver" CausesValidation="false" OnClick="btn_volver_Click" /></td></tr>
                                            <tr>
                                                <td class="tdEncabezado">
                                                    <uc3:tpDatosTerraPlus ID="tpDatosTerraPlus1" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="panel_registro" runat="server" GroupingText="Nuevo contrato TerraPlus">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <uc4:tpContratoAbm ID="tpContratoAbm1" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btn_insertar" runat="server" Text="Guardar contrato" CausesValidation="true" ValidationGroup="terraplus" OnClick="btn_insertar_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                    </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
