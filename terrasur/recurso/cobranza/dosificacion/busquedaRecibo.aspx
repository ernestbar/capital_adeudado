<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Búsqueda de recibo de cobrador" %>
<%@ Register Src="~/recurso/cobranza/dosificacion/userControl/busquedaViewRecibo.ascx" TagName="busquedaViewRecibo"
    TagPrefix="uc1" %>
<%@ Register Src="~/recurso/cobranza/dosificacion/userControl/busquedaViewDeposito.ascx" TagName="busquedaViewDeposito"
    TagPrefix="uc2" %>
<%@ Register Src="~/recurso/cobranza/dosificacion/userControl/busquedaViewDesactivacion.ascx" TagName="busquedaViewDesactivacion"
    TagPrefix="uc4" %>
<%@ Register Src="~/recurso/cobranza/dosificacion/userControl/busquedaViewDosificacion.ascx" TagName="busquedaViewDosificacion"
    TagPrefix="uc5" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "dosificacion", "buscar") Then
                'btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cliente", "insert")
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
   End Sub

    Protected Sub btn_busqueda_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        bvrecibo0.numero_recibo = Int32.Parse(txt_no_recibo.Text)
        bvdosif0.numero_recibo = Int32.Parse(txt_no_recibo.Text)
        bvdepos0.numero_recibo = Int32.Parse(txt_no_recibo.Text)
        bvdesact0.numero_recibo = Int32.Parse(txt_no_recibo.Text)
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc3:recursoMaster ID="RecursoMaster1" runat="server" recurso="dosificacion" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <table class="viewEntTable">
        <tr>
            <td class="viewEntTd">
                <table class="viewTable" align="center">
                    <tr>
                        <td class="formTdMsg" colspan="2">
                            <asp:Msg ID="Msg1" runat="server">
                            </asp:Msg>
                            <asp:ValidationSummary ID="vs_dosificacion" runat="server" DisplayMode="List" ValidationGroup="dosificacion" />
                        </td>
                    </tr>
                    <tr>
                        <td class="viewTdTitle">
                            <asp:Label ID="lbl_title" runat="server" Text="Búsqueda de recibo de cobrador"  ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdFiltro" >
                            <asp:Panel ID="panel_busqueda" runat="server" Width="100%" DefaultButton="btn_busqueda">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun">
                                            <asp:Label  ID="lbl_no_recibo_enun" runat="server" Text="No. de recibo:" />
                                        </td>
                                        <td class="formTdDato">
                                            <asp:Textbox ID="txt_no_recibo" runat="server" Text="" SkinID="txtSingleLine100" />
                                            <asp:RequiredFieldValidator ID="rfv_busqueda" runat="server" ControlToValidate="txt_no_recibo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="dosificacion" Text="*" ErrorMessage="Debe introducir un valor"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="rav_busqueda" runat="server" Type="Integer"  MinimumValue="0" MaximumValue="99999999" ControlToValidate="txt_no_recibo"  Display="Dynamic" ValidationGroup="dosificacion" SetFocusOnError="true" Text="*" ErrorMessage="El número de recibo contiene caracteres inválidos"></asp:RangeValidator>   
                                            <asp:Button ID="btn_busqueda" runat="server" Text="Buscar recibo" OnClick="btn_busqueda_Click"  ValidationGroup="dosificacion"/>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel> </td>
                    </tr>
                    <tr>
                        <td>
                                <uc1:busquedaViewRecibo ID="bvrecibo0" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                                <uc5:busquedaViewDosificacion ID="bvdosif0" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                                <uc2:busquedaViewDeposito ID="bvdepos0" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                                <uc4:busquedaViewDesactivacion ID="bvdesact0" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

