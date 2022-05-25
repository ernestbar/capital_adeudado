<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Finanzas" %>
<%@ Register Src="~/recurso/userControl/webPart/contratoWP.ascx" TagName="contratoWP" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/webPart/clienteZonaWP.ascx" TagName="clienteZonaWP" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/webPart/herramientaWP.ascx" TagName="herramientaWP" TagPrefix="uc3" %>
<%@ Register Src="~/recurso/userControl/webPart/cajaWP.ascx" TagName="cajaWP" TagPrefix="uc4" %>
<%@ Register Src="~/recurso/userControl/webPart/marketingWP.ascx" TagName="marketingWP" TagPrefix="uc5" %>
<%@ Register Src="~/recurso/userControl/webPart/inventarioWP.ascx" TagName="inventarioWP" TagPrefix="uc6" %>
<%@ Register Src="~/recurso/userControl/webPart/cobranzaWP.ascx" TagName="cobranzaWP" TagPrefix="uc7" %>
<%@ Register Src="~/recurso/userControl/webPart/contabilidadWP.ascx" TagName="contabilidadWP" TagPrefix="uc8" %>
<%@ Register Src="~/recurso/userControl/webPart/parametroWP.ascx" TagName="parametroWP" TagPrefix="uc9" %>
<%@ Register Src="~/recurso/userControl/webPart/auditoriaWP.ascx" TagName="auditoriaWP" TagPrefix="uc10" %>
<%@ Register src="~/recurso/userControl/webPart/legalWP.ascx" tagname="legalWP" tagprefix="uc12" %>
<%@ Register src="~/recurso/userControl/webPart/sintesisWP.ascx" tagname="sintesisWP" tagprefix="uc13" %>
<%@ Register src="~/recurso/userControl/webPart/terraplusWP.ascx" tagname="terraplusWP" tagprefix="uc14" %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            VerificacionIpHost()
        End If
    End Sub
    
    Protected Sub VerificacionIpHost()
        If Request.UserHostAddress <> Profile.entorno.context_ip Then
            Dim computador_usuario_ip As String = Request.UserHostAddress
            Dim computador_usuario_nombre As String = ""
            Try
                Dim computer_name As String() = System.Net.Dns.GetHostEntry(Request.ServerVariables("remote_addr")).HostName.Split(".")
                computador_usuario_nombre = computer_name(0).ToString
            Catch ex As Exception
                computador_usuario_nombre = computador_usuario_ip
            End Try
            Profile.entorno.context_ip = computador_usuario_ip
            Profile.entorno.context_host = computador_usuario_nombre
        End If
    End Sub
    
    Protected Sub lb_cambiar_datos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_cambiar_datos.Click
        Response.Redirect("~/recurso/usuario/usuarioTodos/usuarioCambiarDatos.aspx")
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:WebPartManager ID="WebPartManager1" runat="server"></asp:WebPartManager>
    <table class="wpTableZone" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3" class="wpTdUserUpdate">
                <asp:LinkButton ID="lb_cambiar_datos" runat="server" SkinID="lbUserUpdate" Text="Actualizar datos personales"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="wpTdZoneLeft">
                <asp:WebPartZone ID="WebPartZone1" runat="server">
                    <ZoneTemplate>
                        <uc2:clienteZonaWP ID="ClienteZonaWP1" runat="server" Title="Clientes y Zonificación"/>
                        <uc5:marketingWP ID="MarketingWP1" runat="server" Title="Marketing" />
                        <uc6:InventarioWP ID="InventarioWP1" runat="server"  Title="Inventario"/>
                        <uc9:parametroWP ID="ParametroWP1" runat="server" Title="Parámetros del Sistema" />
                        <uc10:auditoriaWP ID="AuditoriaWP1" runat="server" Title="Auditoría" />
                    </ZoneTemplate>
                </asp:WebPartZone>
            </td>
            <td class="wpTdZoneCenter">
                <asp:WebPartZone ID="WebPartZone2" runat="server">
                    <ZoneTemplate>
                        <uc4:cajaWP ID="CajaWP1" runat="server" Title="Caja" />
                        <uc8:contabilidadWP ID="ContabilidadWP1" runat="server" Title="Contabilidad" />
                    </ZoneTemplate>
                </asp:WebPartZone>
            </td>
            <td class="wpTdZoneRight">
                <asp:WebPartZone ID="WebPartZone3" runat="server">
                    <ZoneTemplate>
						<uc14:terraplusWP ID="terraplusWP1" runat="server" Title="TerraPlus" />
						<uc13:sintesisWP ID="sintesisWP1" runat="server" Title="Cobranza por Síntesis" />
                        <uc3:herramientaWP ID="HerramientaWP1" runat="server" Title="Herramientas" />
                        <uc12:legalWP ID="legalWP1" runat="server" Title="Datos Dpto. Legal" />
                        <uc1:contratoWP ID="ContratoWP1" runat="server" Title="Contratos" />
                        <uc7:cobranzaWP ID="CobranzaWP1" runat="server" Title="Cobranza" />
                    </ZoneTemplate>
                </asp:WebPartZone>
            </td>
        </tr>
    </table>
</asp:Content>
