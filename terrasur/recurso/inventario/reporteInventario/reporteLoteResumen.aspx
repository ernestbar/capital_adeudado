<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Inventario de lotes (Resumen)" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteInventario", "reporteLoteResumen") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    'Protected Sub ddl_negocio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ddl_negocio.Items.Insert(0, New ListItem("Todos", "0"))
    'End Sub

    Protected Sub cbl_negocio_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbl_negocio.DataBound
        For Each item As ListItem In cbl_negocio.Items
            item.Selected = True
        Next
    End Sub
    
    Public Sub cargarReporte()
        If rbl_orden.SelectedValue = "negocio" Then
            Dim reporte As New rpt_lote_resumen()
            reporte.DataSource = inventarioReporte.ReporteLoteResumen(cp_fecha.SelectedDate, general.StringNegocios(True, cbl_negocio.Items))
            Reporte1.WebView.Report = reporte
        Else
            Dim reporte As New rpt_lote_resumenSector
            reporte.DataSource = inventarioReporte.ReporteLoteResumenSector(cp_fecha.SelectedDate)
            Reporte1.WebView.Report = reporte
        End If
    End Sub


    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        cargarReporte()
    End Sub
  
    Protected Sub rbl_orden_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_orden.SelectedIndexChanged
        cbl_negocio.Enabled = rbl_orden.SelectedValue.Equals("negocio")
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
<uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteInventario" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
<table class="priTable">
    <tr>
        <td class="priTdTitle">Inventario de lotes (Resumen)</td>
    </tr>
    <tr>
        <td class="priTdContenido">
            <table class="tableContenido" align="center">
                <tr>
                    <td class="tdButtonVolver">
                    </td>
                </tr>
                <tr>
                    <td class="tdFiltro">
                        <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="formTdEnun">Inventario al:</td>
                                <td class="formTdDato">
                                    <ew:CalendarPopup ID="cp_fecha" runat="server" AutoPostBack="false" >
                                    </ew:CalendarPopup>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Ordenar por:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_orden" runat="server" AutoPostBack="true" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Negocio" Value="negocio" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Sector" Value="sector"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Negocio:</td>
                                <td class="formTdDato">
                                    <asp:CheckBoxList ID="cbl_negocio" runat="server" AutoPostBack="false" DataSourceID="ods_negocio_lista" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2"></asp:CheckBoxList>
                                    <%--[id_lote],[codigo]--%>
                                    <asp:ObjectDataSource ID="ods_negocio_lista" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista"></asp:ObjectDataSource>
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

