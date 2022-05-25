<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Control diario de recibos oficiales por cobrador" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCobranza", "reporteControlDiario") Then
                ddl_cobrador.DataBind()
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
      
    Public Sub cargarReporte()
        Dim reporte As New rpt_control_diario_recibos()
        reporte.Encabezado(cp_desde.SelectedDate, cp_hasta.SelectedDate, Int32.Parse(ddl_cobrador.SelectedValue.Trim()))
        reporte.DataSource = cobranzaReporte.ReporteControlDiarioRecibos(cp_desde.SelectedDate, cp_hasta.SelectedDate, Int32.Parse(ddl_cobrador.SelectedValue.Trim()))
        Reporte1.WebView.Report = reporte
    End Sub
        

    Protected Sub ddl_cobrador_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_cobrador.DataBound
        ddl_cobrador.Items.Insert(0, New ListItem("Todos", "0"))
        ddl_cobrador.SelectedValue = "0"
    End Sub

    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        cargarReporte()
    End Sub

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
 <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteCobranza" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<asp:ScriptManager runat="server">
    </asp:ScriptManager>
<table class="priTable">
    <tr>
        <td class="priTdTitle">Control diario de recibos oficiales por cobrador</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido">
                <tr>
                    <td class="tdButtonVolver">
                    </td>
                </tr>
                <tr>
                    <td class="tdFiltro">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_desde" runat="server" Text="Desde:"></asp:Label></td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="cp_desde" runat="server" AutoPostBack="false">
                                    </ew:CalendarPopup>
                                </td>
                            </tr>
                             <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_hasta" runat="server" Text="Hasta:"></asp:Label></td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="cp_hasta" runat="server" AutoPostBack="false" >
                                    </ew:CalendarPopup>
                                </td>
                            </tr>
                           <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_cobrador_enun" runat="server" Text="Cobrador:"></asp:Label></td>
                               <td class="formTdDato">
                                   <asp:DropDownList ID="ddl_cobrador" runat="server" AutoPostBack="false" DataSourceID="ods_cobrador_lista"
                                       DataTextField="nombre_completo" DataValueField="id_usuario">
                                   </asp:DropDownList>
                                   <%--[id_localizacion],[nombre]--%>
                                   <asp:ObjectDataSource ID="ods_cobrador_lista" runat="server" TypeName="terrasur.cobrador"
                                       SelectMethod="ListaNoEliminado"></asp:ObjectDataSource>
                               </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton" colspan="2">
                                   <asp:Button ID="btn_mostrar" runat="server" SkinID="btnAccion" Text="Mostrar reporte"/>
                                </td>
                            </tr>
                         </table>
                    </td>
                </tr>
                <tr>
                    <td class="tdGrid">
                    <uc1:reporte ID="Reporte1" runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

