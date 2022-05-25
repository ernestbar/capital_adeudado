<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Parámetros Fijos" %>
<%@ Register Src="~/recurso/parametro/fijo/userControl/fijoViewDato.ascx" TagName="fijoViewDato" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "fijo", "view") Then

            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="fijo" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
        <tr><td class="priTdTitle">Parámetros Fijos</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View id="View1" runat="server">
                       <asp:Panel ID="panel_abm" runat="server">
                        <table class="formEntTable">
                            <tr>
                                <td class="formEntTdTitle">
                                    <%--<asp:Label ID="lbl_preasig_abm"  Text="Preasignación" runat="server"></asp:Label>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdForm">
                                 <uc1:fijoViewDato ID="FijoViewDato1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton">
                                    <%--<asp:Button ID="btn_insertar" runat="server" Text="Guardar" CausesValidation="true" ValidationGroup="[...]" SkinID="btnAccion" />
                                    <asp:Button ID="btn_actualizar" runat="server" Text="Actualizar" CausesValidation="true" ValidationGroup="[...]" SkinID="btnAccion" />
                                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar / Volver" CausesValidation="false" SkinID="btnAccion" />--%>
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

