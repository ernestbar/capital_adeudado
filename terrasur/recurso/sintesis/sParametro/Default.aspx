<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Parámetros para Síntesis" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>

<%@ Register src="~/recurso/sintesis/sParametro/userControl/sTipoCambioAbm.ascx" tagname="sTipoCambioAbm" tagprefix="uc3" %>
<%@ Register src="~/recurso/sintesis/sParametro/userControl/sHorarioAbm.ascx" tagname="sHorarioAbm" tagprefix="uc4" %>
<%@ Register src="~/recurso/sintesis/sParametro/userControl/sTipoPagoView.ascx" tagname="sTipoPagoView" tagprefix="uc5" %>
<%@ Register src="~/recurso/sintesis/sParametro/userControl/sEeffAbm.ascx" tagname="sEeffAbm" tagprefix="uc6" %>
<%@ Register src="~/recurso/sintesis/sParametro/userControl/sParametrosVarios.ascx" tagname="sParametrosVarios" tagprefix="uc7" %>
<%@ Register src="~/recurso/sintesis/sParametro/userControl/sMensajeReciboAbm.ascx" tagname="sMensajeReciboAbm" tagprefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sParametro", "view") Then
                sTipoCambioAbm1.Cargar()
                sHorarioAbm1.Cargar()
                sTipoPagoView1.Cargar()
                
                sParametrosVarios1.Cargar()
                sEeffAbm1.Cargar()
                sMensajeReciboAbm1.Cargar()
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="sParametro" MostrarLink="true"/>
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server"><Scripts><asp:ScriptReference Path="../../../js/scriptjs.js" /></Scripts></asp:ScriptManager>
<table class="priTable" width="100%">
    <tr><td class="priTdTitle">Parámetros para Síntesis</td></tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido" align="center">
                <tr>
                    <td valign="top">
                        <table cellpadding="0" cellpadding="0">
                            <tr><td><uc3:sTipoCambioAbm ID="sTipoCambioAbm1" runat="server" /></td></tr>
                            <tr><td><br /></td></tr>
                            <tr><td><uc4:sHorarioAbm ID="sHorarioAbm1" runat="server" /></td></tr>
                            <tr><td><br /></td></tr>
                            <tr><td><uc2:sMensajeReciboAbm ID="sMensajeReciboAbm1" runat="server" /></td></tr>
                        </table>
                    </td>
                    <td valign="top">
                        <table cellpadding="0" cellpadding="0">
                            <tr><td><uc7:sParametrosVarios ID="sParametrosVarios1" runat="server" /></td></tr>
                            <tr><td><br /></td></tr>
                            <tr><td><uc6:sEeffAbm ID="sEeffAbm1" runat="server" /></td></tr>
                            <tr><td><br /></td></tr>
                            <tr><td><uc5:sTipoPagoView ID="sTipoPagoView1" runat="server" /></td></tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    </table>
</asp:Content>

