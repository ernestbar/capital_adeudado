<%@ Page Language="C#" MasterPageFile="~/modulo/normal.master" Title="Parámetros TerraPlus" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register src="~/recurso/terraplus/tpParametro/userControl/tParametroAbm.ascx" tagname="tParametroAbm" tagprefix="uc1" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "tpParametro", "view"))
            { tParametroAbm1.Cargar(); }
            else { Response.Redirect("~/modulo/" + Profile.entorno.codigo_modulo + "/Default.aspx"); }
        }
    }
    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="tpParametro" MostrarLink="true" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>

    <table class="priTable">
        <tr><td class="priTdTitle">Parámetros TerraPlus</td></tr>
        <tr>
            <td class="priTdContenido">
                <table class="tableContenido" align="center">
                    <tr>
                        <td>
                            <uc1:tParametroAbm ID="tParametroAbm1" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

