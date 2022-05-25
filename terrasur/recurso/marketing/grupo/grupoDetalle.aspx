<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Datos del grupo de venta" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>

<script runat="server">
    Public Property id_grupoventa() As Integer
        Get
            Return Integer.Parse(lbl_id_grupoventa.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_grupoventa.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_grupoventa") IsNot Nothing Then
                Dim grupoObj As New grupo_venta(Integer.Parse(Session("id_grupoventa").ToString))
                id_grupoventa = grupoObj.id_grupoventa
                Page.Title = "Datos del grupo de venta - " & grupoObj.nombre & " (" & grupoObj.nombre_director & ")"
                lbl_nombre.Text = grupoObj.nombre
                lbl_director.Text = grupoObj.nombre_director
                If grupoObj.activo Then
                    lbl_activo.Text = "Grupo de ventas ACTIVO"
                Else
                    lbl_activo.Text = "Grupo de ventas INACTIVO"
                End If
                If grupoObj.en_planilla Then
                    lbl_planilla.Text = "Grupo de ventas EN PLANILLA"
                Else
                    lbl_planilla.Text = "Grupo de ventas FUERA DE PLANILLA"
                End If
                Session.Remove("id_grupoventa")
            Else
                Page.Visible = False
            End If
        End If
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="grupo" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_id_grupoventa" runat="server" Text="0" Visible="false"></asp:Label>
    <table class="viewEntTable">
        <tr>
            <td class="viewEntTd">
                <table class="viewTable" align="center">
                    <tr><td colspan="2" class="viewTdTitle">Datos del grupo de ventas</td></tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_nombre_enun" runat="server" Text="Nombre del grupo:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_nombre" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_director_enun" runat="server" Text="Director de ventas:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_director" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_activo_enun" runat="server" Text="Activo:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_activo" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_planilla_enun" runat="server" Text="En planilla:"></asp:Label></td>
                        <td class="viewTdDato"><asp:Label ID="lbl_planilla" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="viewTdEnun"><asp:Label ID="lbl_promotor_enun" runat="server" Text="Promotores del grupo:"></asp:Label></td>
                        <td class="viewTdDato">
                            <asp:GridView ID="gv_promotor" runat="server" ShowHeader="false" AutoGenerateColumns="false" DataSourceID="ods_grupo" DataKeyNames="id_grupopromotor" >
                                <Columns><asp:BoundField DataField="nombre_completo" /></Columns>
                                <EmptyDataTemplate>El grupo no tiene promotores</EmptyDataTemplate>
                            </asp:GridView>
                            <%--[id_grupopromotor],[id_usuario],[nombre_completo],[ci],[nombre_usuario]--%>
                            <asp:ObjectDataSource ID="ods_grupo" runat="server" TypeName="terrasur.grupo_promotor" SelectMethod="ListaPromotorPorGrupo">
                                <SelectParameters>
                                    <asp:ControlParameter Name="Id_grupoventa" Type="Int32" ControlID="lbl_id_grupoventa" PropertyName="Text" />
                                    <asp:Parameter Name="Ids_promotores" Type="String" DefaultValue="" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>