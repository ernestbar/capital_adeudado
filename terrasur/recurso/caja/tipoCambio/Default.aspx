<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Tipo de cambio" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/caja/tipoCambio/userControl/tipoCambioAbm.ascx" TagName="tipoCambioAbm" TagPrefix="uc1" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            TipoCambioAbm1.Cargar(DateTime.Now.Date)
        End If
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="tipoCambio" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle">Tipo de cambio</td></tr>
        <tr>
            <td class="priTdContenido">
                <uc1:tipoCambioAbm ID="TipoCambioAbm1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
