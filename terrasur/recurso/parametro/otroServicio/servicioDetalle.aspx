<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Untitled Page" %>
<%@ Register Src="~/recurso/parametro/otroServicio/userControl/servicioViewDato.ascx" TagName="servicioViewDato" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_servicio") IsNot Nothing Then
                ServicioViewDato1.id_servicio = Integer.Parse(Session("id_servicio").ToString)
                Dim s As New servicio(Integer.Parse(Session("id_servicio").ToString))
                Page.Title = "Datos del servicio - " & s.codigo & " -  " & s.nombre & ")"
                Session.Remove("id_servicio")
            Else
                Page.Visible = False
            End If
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc3:recursoMaster ID="RecursoMaster1" runat="server" recurso="otroServicio" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="viewHorEntTable">
        <tr>
            <td class="viewHorEntTd">
                <table class="viewHorTable" align="center">
                    <tr>
                        <td class="viewHorTdTitle">
                            <asp:Label ID="lbl_title" runat="server" Text="Datos del servicio"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_datos" runat="server" Width="100%" GroupingText="">
                                <uc1:servicioViewDato ID="ServicioViewDato1" runat="server" />
                                
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

