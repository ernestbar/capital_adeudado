<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Datos detallados del lote (para el dpto. Legal)" %>
<%@ Register Src="~/recurso/legal/negocioFolio/userControl/legalLoteViewDato.ascx" TagName="legalLoteViewDato" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_lote") IsNot Nothing Then
                LegalLoteViewDato1.id_lote = Integer.Parse(Session("id_lote").ToString)
                Dim l As New lote(Integer.Parse(Session("id_lote").ToString))
                Page.Title = "Datos detallados del lote (para el dpto. Legal) - " & l.nombre_localizacion & "/" & l.nombre_urbanizacion & "/" & l.codigo_manzano & "/" & l.codigo
                Session.Remove("id_lote")
            Else
                Page.Visible = False
            End If
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc3:recursoMaster ID="RecursoMaster1" runat="server" recurso="lote" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager runat="server" ID="ScriptManager1">
    </asp:ScriptManager>
    <table class="viewHorEntTable">
        <tr>
            <td class="viewHorEntTd">
                <table class="viewHorTable" align="center">
                    <tr>
                        <td class="viewHorTdTitle">
                            <asp:Label ID="lbl_title" runat="server" Text="Datos detallados del lote (para el dpto. Legal)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_datos" runat="server" Width="100%" GroupingText="">
                                <uc1:legalLoteViewDato ID="LegalLoteViewDato1" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

