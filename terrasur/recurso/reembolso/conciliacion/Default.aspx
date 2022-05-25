<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Conciliaciones" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagPrefix="uc1" TagName="recursoMaster" %>
<%@ Register Src="~/recurso/reembolso/conciliacion/userControl/conciliaAbm.ascx" TagPrefix="uc2" TagName="conciliaAbm" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "conciliacion", "view"))
            {
                btn_insertar.Visible  = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "conciliacion", "insert");
                panel_abm.DefaultButton = "btn_insertar";
                lbl_abm.Text = "Nueva conciliación";
                conciliaAbm1.CargarInsertar();
                MultiView1.ActiveViewIndex = 0;
            }
            else
            {
                Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx");
            }
        }
    }

    protected void btn_insertar_Click(object sender, EventArgs e)
    {
        if (conciliaAbm1.Insertar())
        {
            conciliaAbm1.CargarInsertar();
        }
        panel_abm.DefaultButton = "btn_insertar";
    }

    //protected void btn_cancelar_Click(object sender, EventArgs e)
    //{
    //    MultiView1.ActiveViewIndex = 0;
    //}
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="recursoMaster1" runat="server" recurso="conciliacion" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/reembolso/traspaso/reembolsoDatosSimple.aspx" Visible="False" 
        Win_Directories="False" Win_Fullscreen="False" Win_Height="550" Win_Width="900" Win_Left="100" Win_Top="100" 
        Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True" Win_Status="True" 
        Win_Titlebar="True" Win_Toolbar="False">[WinPopUp1]</asp:WinPopUp>
    <asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle">Conciliaciones</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                        <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr><td class="formEntTdTitle"><asp:Label ID="lbl_abm" runat="server"></asp:Label></td></tr>
                            <tr><td class="formEntTdForm">
                                <uc2:conciliaAbm runat="server" ID="conciliaAbm1" />
                            </td></tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <asp:ButtonAction ID="btn_insertar" runat="server" Text="<%$ Resources:form, btn_insertar %>" TextoEnviando="<%$ Resources:form, btn_insertar_click %>" CausesValidation="true" ValidationGroup="reembolso" OnClick="btn_insertar_Click" />
                                    <%--<asp:Button ID="btn_cancelar" runat="server" Text="<%$ Resources:form, btn_cancelar %>" CausesValidation="false" SkinID="btnAccion" OnClick="btn_cancelar_Click" />--%>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>

