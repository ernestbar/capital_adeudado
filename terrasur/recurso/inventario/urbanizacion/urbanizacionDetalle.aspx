<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Datos del sector" %>
<%@ Register Src="~/recurso/inventario/urbanizacion/userControl/urbanizacionViewDato.ascx" TagName="urbanizacionViewDato"
    TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc3" %>

<script runat="server">
 Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_urbanizacion") IsNot Nothing Then
                UrbanizacionViewDato1.id_urbanizacion = Integer.Parse(Session("id_urbanizacion").ToString)
                Dim u As New urbanizacion(Integer.Parse(Session("id_urbanizacion").ToString))
                Page.Title = "Datos del sector - (" & u.codigo & ") -  " & u.nombre & ""
                Session.Remove("id_urbanizacion")
            Else
                Page.Visible = False
            End If
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc3:recursoMaster ID="RecursoMaster1" runat="server" recurso="urbanizacion" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="viewHorEntTable">
        <tr>
            <td class="viewHorEntTd">
                <table class="viewHorTable" align="center">
                    <tr>
                        <td class="viewHorTdTitle">
                            <asp:Label ID="lbl_title" runat="server" Text="Datos del sector"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_datos" runat="server" Width="100%" GroupingText="">
                                <uc1:urbanizacionViewDato ID="UrbanizacionViewDato1" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

