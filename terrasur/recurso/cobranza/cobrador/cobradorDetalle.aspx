<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Untitled Page" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>

<script runat="server">
    Public Property id_usuario() As Integer
        Get
            Return Integer.Parse(lbl_id_usuario.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_usuario.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_cobrador") IsNot Nothing Then
                Dim usr As New cobrador(Integer.Parse(Session("id_cobrador").ToString))
                id_usuario = usr.id_usuario
                img_imagen.ImageUrl = usuario.ImagenDireccion(usr.imagen)
                lbl_paterno.Text = usr.paterno
                lbl_materno.Text = usr.materno
                lbl_nombres.Text = usr.nombres
                lbl_ci.Text = usr.ci
                lbl_email.Text = usr.email
                If usr.activo Then
                    lbl_activo.Text = "cobrador Activo"
                Else
                    lbl_activo.Text = "cobrador Inactivo"
                End If
                lbl_usuario.Text = usr.nombre_usuario

                Page.Title = "Datos del cobrador - " & usr.paterno & " " & usr.materno & " " & usr.nombres & ""
                Session.Remove("id_cobrador")
            Else
                Page.Visible = False
            End If
        End If
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
      <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="cobrador" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
     <asp:Label ID="lbl_id_usuario" runat="server" Text="0" Visible="false"></asp:Label>
    <table class="viewEntTable">
        <tr>
            <td class="viewEntTd">
                <table class="viewTable" align="center">
                    <tr><td class="viewTdTitle" colspan="2">Datos del cobrador</td></tr>
                    <tr><td class="viewTdImage" colspan="2"><asp:Image ID="img_imagen" runat="server" Height="<%$ AppSettings:usuario_tam_img %>" /></td></tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_paterno_enun" runat="server" Text="Apellido paterno:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_paterno" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_materno_enun" runat="server" Text="Apellido materno:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_materno" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_nombres_enun" runat="server" Text="Nombres:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_nombres" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_ci_enun" runat="server" Text="Nº doc. de identidad:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_ci" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_email_enun" runat="server" Text="Dirección Email:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_email" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_activo_enun" runat="server" Text="Activo:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_activo" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_usuario_enun" runat="server" Text="Usuario:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_usuario" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

