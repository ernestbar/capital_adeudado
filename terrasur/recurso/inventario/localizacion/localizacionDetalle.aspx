<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Datos de la localización" %>
<%@ Register Src="~/recurso/inventario/localizacion/userControl/localizacionViewDato.ascx" TagName="localizacionViewDato"
    TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_localizacion") IsNot Nothing Then
                LocalizacionViewDato1.id_localizacion = Integer.Parse(Session("id_localizacion").ToString)
                Dim l As New localizacion(Integer.Parse(Session("id_localizacion").ToString))
                Page.Title = "Datos de la localización - (" & l.codigo & ") -  " & l.nombre & ")"
                Session.Remove("id_localizacion")
            Else
                Page.Visible = False
            End If
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc3:recursoMaster ID="RecursoMaster1" runat="server" recurso="localizacion" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="viewHorEntTable">
        <tr>
            <td class="viewHorEntTd">
                <table class="viewHorTable" align="center">
                    <tr>
                        <td class="viewHorTdTitle">
                            <asp:Label ID="lbl_title" runat="server" Text="Datos de la localización"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_datos" runat="server" Width="100%" GroupingText="">
                                <uc1:localizacionViewDato ID="LocalizacionViewDato1" runat="server" />
                           </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

