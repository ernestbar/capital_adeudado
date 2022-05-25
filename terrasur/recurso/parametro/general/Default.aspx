<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Parámetros Generales" %>

<%@ Register Src="~/recurso/parametro/general/userControl/comPromPlanillaAbm.ascx" TagName="comPromPlanillaAbm" TagPrefix="uc10" %>
<%@ Register src="~/recurso/parametro/general/userControl/sucursalPagNafiboAbm.ascx" tagname="sucursalPagNafiboAbm" tagprefix="uc9" %>
<%@ Register Src="~/recurso/parametro/general/userControl/pagNafiboAbm.ascx" TagName="pagNafiboAbm" TagPrefix="uc8" %>
<%@ Register Src="~/recurso/parametro/general/userControl/comDirecAbm.ascx" TagName="comDirecAbm" TagPrefix="uc7" %>
<%@ Register Src="~/recurso/parametro/general/userControl/comPromAbm.ascx" TagName="comPromAbm" TagPrefix="uc6" %>
<%@ Register Src="~/recurso/parametro/general/userControl/fatoresAbm.ascx" TagName="fatoresAbm" TagPrefix="uc5" %>
<%@ Register Src="~/recurso/parametro/general/userControl/reversionesAbm.ascx" TagName="reversionesAbm" TagPrefix="uc4" %>
<%@ Register Src="~/recurso/parametro/general/userControl/carteraAbm.ascx" TagName="carteraAbm" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/parametro/general/userControl/preasigAbm.ascx" TagName="preasigAbm" TagPrefix="uc3" %>
<%@ Register src="~/recurso/parametro/general/userControl/pagoCasasSucursales.ascx" tagname="pagoCasasSucursales" tagprefix="uc11" %>
<%@ Register src="~/recurso/parametro/general/userControl/cuoIniPorcentMinFinal.ascx" tagname="cuoIniPorcentMinFinal" tagprefix="uc12" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>




<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "general", "view") Then
                
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="general" MostrarLink="true" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr><td class="priTdTitle">Parámetros Generales</td></tr>
    <tr>
        <td class="priTdContenido">
           <asp:Panel ID="panel_abm" runat="server">
            <table class="formEntTable">
                <tr>
                    <td class="formEntTdForm">
                        <table align="center">
                            <tr><td><uc3:preasigAbm ID="PreasigAbm1" runat="server" /></td></tr>
                            <tr><td><uc1:carteraAbm ID="CarteraAbm1" runat="server" /></td></tr>
                            <%--<tr><td><uc4:reversionesAbm id="ReversionesAbm1" runat="server"/></td></tr>
                            <tr><td><uc10:comPromPlanillaAbm ID="ComPromPlanillaAbm1" runat="server" /></td></tr>--%>
                            <tr><td><uc8:pagNafiboAbm ID="PagNafiboAbm1" runat="server" /></td></tr>
                            <tr><td><uc9:sucursalPagNafiboAbm ID="sucursalPagNafiboAbm1" runat="server" /></td></tr>
                            <tr><td><uc11:pagoCasasSucursales ID="pagoCasasSucursales1" runat="server" /></td></tr>
                            <tr><td><uc6:comPromAbm ID="ComPromAbm1" runat="server" /></td></tr>
                            <tr><td><uc12:cuoIniPorcentMinFinal ID="cuoIniPorcentMinFinal1" runat="server" /></td></tr>
                        </table>
                    </td>
                </tr>
            </table>
            </asp:Panel>
        </td>
    </tr>
</table> 
</asp:Content> 

