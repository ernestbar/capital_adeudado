<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Registro de Servicio Prestado TerraPlus" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpContratoBusqueda.ascx" tagname="tpContratoBusqueda" tagprefix="uc2" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpDatosTerraPlus.ascx" tagname="tpDatosTerraPlus" tagprefix="uc3" %>
<%@ Register src="~/recurso/terraplus/tpServicioPrestado/userControl/tpServicioPrestadoAbm.ascx" tagname="tpServicioPrestadoAbm" tagprefix="uc4" %>

<script runat="server">
    private int id_contrato_terraplus { get { return int.Parse(lbl_id_contrato_terraplus.Text); } set { lbl_id_contrato_terraplus.Text = value.ToString(); } }
        
    protected void Page_Load(object sender, EventArgs e)
    {
        this.tpContratoBusqueda1.Eleccion += new EventHandler(busqueda_realizada);
        
        if (!Page.IsPostBack)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpServicioPrestado", "insert")) { tpContratoBusqueda1.Reset(); }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    protected void busqueda_realizada(object sender, System.EventArgs e)
    {
        id_contrato_terraplus = tpContratoBusqueda1.id_resultado;

        if (id_contrato_terraplus > 0)
        {
            terrasur.terraplus.tp_estado_contrato ecObj = new terrasur.terraplus.tp_estado_contrato(terrasur.terraplus.tp_estado_contrato.Actual(id_contrato_terraplus));
            if (ecObj.estado_codigo == "restriccion" || ecObj.estado_codigo == "cobertura")
            {
                MultiView1.ActiveViewIndex = 1;
                tpDatosTerraPlus1.id_contrato = id_contrato_terraplus;

                panel_registro.Visible = true;
                tpServicioPrestadoAbm1.Cargar(id_contrato_terraplus);
            }
            else { Msg1.Text = "No se puede registrar el Servicio Prestado de un contrato cuyo estado es: " + ecObj.estado_nombre; }
        }
        else { Msg1.Text = "El cliente NO tiene un contrato TerraPlus vigente"; }
    }
    
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        tpContratoBusqueda1.Reset();
    }

    protected void btn_insertar_Click(object sender, EventArgs e)
    {
        if (tpServicioPrestadoAbm1.Insertar())
        {
            tpDatosTerraPlus1.id_contrato = id_contrato_terraplus;
            panel_registro.Visible = false;
        }
    }
    


</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="tpServicioPrestado" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Label runat="server" ID="lbl_id_contrato_terraplus" Visible="false" Text="0"></asp:Label>
    <table class="priTable">
        <tr><td class="priTdTitle">Registro de Servicio Prestado TerraPlus</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table class="tableContenido" align="center">
                            <tr>
                                <td class="tdBusqueda">
                                    <uc2:tpContratoBusqueda ID="tpContratoBusqueda1" runat="server" buscar_contrato="false" />
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
                                            <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro contrato" SkinID="btnVolver" CausesValidation="false" OnClick="btn_volver_Click" /></td></tr>
                                            <tr>
                                                <td class="tdEncabezado">
                                                    <uc3:tpDatosTerraPlus ID="tpDatosTerraPlus1" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="panel_registro" runat="server" GroupingText="Servicio prestado">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <uc4:tpServicioPrestadoAbm ID="tpServicioPrestadoAbm1" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btn_insertar" runat="server" Text="Registrar el Servicio Prestado" CausesValidation="true" ValidationGroup="terraplus" OnClick="btn_insertar_Click" />
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
