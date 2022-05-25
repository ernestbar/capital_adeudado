<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Inventario de lotes y contratos" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteInventario", "reporteLoteContrato") Then
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
        Dim dview As Data.DataView = inventarioReporte.ReporteLoteContrato(cp_fecha.SelectedDate, Integer.Parse(ddl_urbanizacion.SelectedValue), general.StringNegocios(True, cbl_negocio.Items), True, Boolean.Parse(rbl_saldo0.SelectedValue)).DefaultView
        
        Select Case rbl_orden.SelectedValue
            Case "negocio"
                dview.Sort = "sector,negocio desc,num_cuotas_restantes,manzano,lote"
            Case "lote"
                dview.Sort = "sector,sector_codigo,manzano,lote"
            Case "saldo"
                dview.Sort = "sector,saldo"
            Case "num_cuotas"
                dview.Sort = "sector,num_cuotas_restantes"
        End Select

        Dim reporte As New rpt_lote_contrato()
        reporte.DataSource = dview
        reporte.CargarDatos(cp_fecha.SelectedDate, ddl_urbanizacion.SelectedItem.Text, Boolean.Parse(rbl_saldo0.SelectedValue), general.StringNegocios(False, cbl_negocio.Items), rbl_orden.SelectedItem.Text)
        Reporte1.WebView.Report = reporte
        'gv1.DataSource = dview
        'gv1.DataBind()
    End Sub


    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        cargarReporte()
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
        <td class="priTdTitle">Inventario de lotes y contratos</td>
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
                                <td class="formTdEnun">Sector:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_urbanizacion" runat="server" DataSourceID="ods_lista_urbanizacion" DataTextField="nombre" DataValueField="id_urbanizacion">
                                    </asp:DropDownList>
                                    <%--[id_urbanizacion],[codigo],[nombre_corto],[nombre],[mantenimiento_sus],[costo_m2_sus],[precio_m2_sus],[imagen],[activo]--%>
                                    <asp:ObjectDataSource ID="ods_lista_urbanizacion" runat="server" TypeName="terrasur.urbanizacion" SelectMethod="Lista">
                                        <SelectParameters><asp:Parameter Name="Id_localizacion" Type="Int32" DefaultValue="0" /></SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Saldo:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_saldo0" runat="server" CellPadding="0" CellSpacing="0">
                                        <asp:ListItem Text="Incluir contratos vigentes con saldo cancelado" Value="True" Selected="true"></asp:ListItem>
                                        <asp:ListItem Text="No incluir contratos vigentes con saldo cancelado" Value="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Negocio:</td>
                                <td class="formTdDato">
                                    <asp:CheckBoxList ID="cbl_negocio" runat="server" AutoPostBack="false" DataSourceID="ods_negocio_lista" DataTextField="nombre" DataValueField="id_negocio" CellPadding="0" CellSpacing="0" RepeatColumns="2">
                                    </asp:CheckBoxList>
                                    <asp:ObjectDataSource ID="ods_negocio_lista" runat="server" TypeName="terrasur.negocio" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Ordenar por:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_orden" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Negocio" Value="negocio" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Lote" Value="lote"></asp:ListItem>
                                        <asp:ListItem Text="Saldo" Value="saldo"></asp:ListItem>
                                        <asp:ListItem Text="Nº de cuotas restante" Value="num_cuotas"></asp:ListItem>
                                    </asp:RadioButtonList>
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
                        <uc1:reporte ID="Reporte1" runat="server" NombreReporte="ReporteInventarioContrato" />
                        <%--<asp:GridView ID="gv1" runat="server"></asp:GridView>--%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

