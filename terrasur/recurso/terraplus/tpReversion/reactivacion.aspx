<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Reactivación de un contrato TerraPlus" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpContratoBusqueda.ascx" tagname="tpContratoBusqueda" tagprefix="uc2" %>
<%@ Register src="~/recurso/terraplus/tpContrato/userControl/tpDatosTerraPlus.ascx" tagname="tpDatosTerraPlus" tagprefix="uc3" %>
<%@ Register src="~/recurso/terraplus/tpReversion/userControl/tpReactivacionAbm.ascx" tagname="tpReactivacionAbm" tagprefix="uc4" %>
<%--<%@ Register src="~/recurso/terraplus/tpReversion/userControl/tpReversionAbm.ascx" tagname="tpReversionAbm" tagprefix="uc5" %>--%>


<script runat="server">
    private int id_cliente { get { return int.Parse(lbl_id_cliente.Text); } set { lbl_id_cliente.Text = value.ToString(); } }
    private int id_contrato_terraplus { get { return int.Parse(lbl_id_contrato_terraplus.Text); } set { lbl_id_contrato_terraplus.Text = value.ToString(); } }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        this.tpContratoBusqueda1.Eleccion += new EventHandler(busqueda_realizada);

        if (!Page.IsPostBack)
        {
            bool permitir = false;
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpReversion", "reactivar")) 
            { permitir = true; }
            else if (Profile.entorno.codigo_modulo != "adm" && permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpReversion", "reactivar_marketing")) 
            { permitir = true; }
                
            if (permitir)
            {
                tpContratoBusqueda1.Reset();
            }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }

    protected void busqueda_realizada(object sender, System.EventArgs e)
    {
        id_contrato_terraplus = tpContratoBusqueda1.id_resultado;
        id_cliente = tpContratoBusqueda1.id_cliente_terraplus;

        terrasur.terraplus.tp_estado_contrato ecObj = new terrasur.terraplus.tp_estado_contrato(terrasur.terraplus.tp_estado_contrato.Actual(id_contrato_terraplus));
        if (ecObj.estado_codigo == "revertido")
        {
            //se verifica el número de reactivaciones ya realizadas:
            int Num_reactivaciones_realizadas = terrasur.terraplus.tp_contrato.NumReactivaciones(id_contrato_terraplus);
            int Num_reactivaciones_admitidas = Convert.ToInt32(new parametro("tp_reactivacion_num_maximo").valor);
            if (Num_reactivaciones_realizadas < Num_reactivaciones_admitidas)
            {
                bool proceder = true;

                //En caso de que se reactive desde marketing se verifica
                if (Profile.entorno.codigo_modulo != "adm") //if (Profile.entorno.codigo_modulo == "marketing")
                {
                    int Num_meses_incumplimineto_marketing = Convert.ToInt32(new parametro("tp_reactivacion_meses_marketing").valor);
                    int Num_meses_incumplidos = terrasur.terraplus.tp_contrato.NumMesesIncumplidos(id_contrato_terraplus);
                    
                    if (Num_meses_incumplidos <= Num_meses_incumplimineto_marketing) { proceder = true; }
                    else
                    {
                        proceder = false;
                        Msg1.Text = "El número de meses de incumplimiento (" + Num_meses_incumplidos.ToString() + ") del contrato supera los permitidos para la reactivación (" + Num_meses_incumplimineto_marketing.ToString() + ")";
                    }
                }

                if (proceder)
                {
                    //Se carga la ventana de reactivación
                    MultiView1.ActiveViewIndex = 1;
                    tpDatosTerraPlus1.id_contrato = id_contrato_terraplus;
                    panel_registro.Visible = true;
                    tpReactivacionAbm1.Cargar(ecObj.id_reversion);
                }
            }
            else { Msg1.Text = "El contrato ya se reactivó " + Num_reactivaciones_realizadas.ToString() + " veces de las " + Num_reactivaciones_admitidas.ToString() + " permitidas"; }
                
        }
        else { Msg1.Text = "El contrato no esta Revertido"; }
    }

    protected void btn_volver_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        tpContratoBusqueda1.Reset();
    }

    protected void btn_insertar_Click(object sender, EventArgs e)
    {
        if (tpReactivacionAbm1.Reactivar())
        {
            tpDatosTerraPlus1.id_contrato = id_contrato_terraplus;
            panel_registro.Visible = false;
        }
    }

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="tpReversion" MostrarLink="false" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Label runat="server" id="lbl_id_cliente" Visible="false" Text="0"/>
    <asp:Label runat="server" id="lbl_id_contrato_terraplus" Visible="false" Text="0"/>
    <table class="priTable">
        <tr><td class="priTdTitle">Reactivación de un contrato TerraPlus</td></tr>
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
                                            <tr><td class="tdButtonNuevaBusqueda"><asp:Button ID="btn_volver" runat="server" Text="Elegir otro cliente" SkinID="btnVolver" CausesValidation="false" OnClick="btn_volver_Click" /></td></tr>
                                            <tr>
                                                <td class="tdEncabezado">
                                                    <uc3:tpDatosTerraPlus ID="tpDatosTerraPlus1" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="panel_registro" runat="server" DefaultButton="btn_insertar" GroupingText="Reactivación de contrato">
                                                        <table cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <uc4:tpReactivacionAbm ID="tpReactivacionAbm1" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btn_insertar" runat="server" Text="Reactivar" CausesValidation="true" ValidationGroup="terraplus" OnClick="btn_insertar_Click" />
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
