<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Asignación de bonos a promotores" %>
<%@ Register Src="~/recurso/marketing/bonoPromotor/userControl/bonoPromotorAbm.ascx" TagName="bonoPromotorAbm" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "bonoPromotor", "view") Then
                btn_registrar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "bonoPromotor", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub


    Protected Sub btn_registrar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If BonoPromotorAbm1.Registrar = True Then
            BonoPromotorAbm1.Reset()
        End If
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="bonoPromotor" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="priTable">
        <tr><td class="priTdTitle">Bonos a promotores</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_abm" runat="server">
                    <table class="formEntTable">
                        <%--<tr>
                            <td class="formEntTdTitle">
                                <asp:Label ID="lbl_ciclo_abm" runat="server"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td class="formEntTdForm">
                                <uc2:bonoPromotorAbm ID="BonoPromotorAbm1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:ButtonAction ID="btn_registrar" runat="server" Text="Registrar asignación" TextoEnviando="registrando" CausesValidation="true" ValidationGroup="bono" OnClick="btn_registrar_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>