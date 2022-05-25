<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Datos del manzano" %>
<%@ Register Src="~/recurso/inventario/manzano/userControl/manzanoViewDato.ascx" TagName="manzanoViewDato" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_manzano") IsNot Nothing Then
                manzanoViewDato1.id_manzano = Integer.Parse(Session("id_manzano").ToString)
                Dim m As New manzano(Integer.Parse(Session("id_manzano").ToString))
                Page.Title = "Datos del manzano - " & m.codigo & ""
                Session.Remove("id_manzano")
            Else
                Page.Visible = False
            End If
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc3:recursoMaster ID="RecursoMaster1" runat="server" recurso="manzano" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="viewHorEntTable">
        <tr>
            <td class="viewHorEntTd">
                <table class="viewHorTable" align="center">
                    <tr>
                        <td class="viewHorTdTitle">
                            <asp:Label ID="lbl_title" runat="server" Text="Datos del manzano"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_datos" runat="server" Width="100%" GroupingText="">
                                <uc1:manzanoViewDato ID="ManzanoViewDato1" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

