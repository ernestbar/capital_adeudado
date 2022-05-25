<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Datos de un grupo de transacciones" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>
<script runat="server">
    Protected Property id_grupotransaccion() As Integer
        Get
            Return Integer.Parse(lbl_id_grupotransaccion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_grupotransaccion.Text = value
        End Set
    End Property
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Session("id_grupotransaccion") IsNot Nothing Then
                id_grupotransaccion = Integer.Parse(Session("id_grupotransaccion").ToString)
                Session.Remove("id_grupotransaccion")
                
                Dim repObj As New rpt_grupo_transaccion()
                repObj.DataSource = tarjeta_credito_transaccion.ListaTransacciones(0, id_grupotransaccion, "todos")
                repObj.CargarDatos(id_grupotransaccion, "Transacciones a realizar")
                Reporte1.WebView.Report = repObj
            Else
                Page.Visible = False
            End If
        End If
    End Sub

    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        Dim repObj As New rpt_grupo_transaccion()
        repObj.DataSource = tarjeta_credito_transaccion.ListaTransacciones(0, id_grupotransaccion, ddl_tipo.SelectedValue)
        repObj.CargarDatos(id_grupotransaccion, ddl_tipo.SelectedItem.Text)
        Reporte1.WebView.Report = repObj
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="grupo_transaccion" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_id_grupotransaccion" runat="server" Text="0" Visible="false"></asp:Label>
    <table class="viewEntTable">
        <tr>
            <td class="viewEntTd">
                <table class="viewTable" align="center">
                    <tr><td class="viewTdTitle">Datos de un grupo de transacciones</td></tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" align="left">
                                <tr>
                                    <td><asp:Label ID="lbl_tipo_enun" runat="server" Text="Tipo de transacciones:" SkinID="lblEnun"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="ddl_tipo" runat="server">
                                            <asp:ListItem Text="Transacciones a realizar" Value="todos" Selected="True" />
                                            <asp:ListItem Text="Debitos aceptados" Value="aceptados" />
                                            <asp:ListItem Text="Debitos denegados" Value="denegados" />
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:ButtonAction ID="btn_mostrar" runat="server" Text="Mostrar reporte" TextoEnviando="Generando reporte ..." />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr><td><uc2:reporte ID="Reporte1" runat="server" /></td></tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

