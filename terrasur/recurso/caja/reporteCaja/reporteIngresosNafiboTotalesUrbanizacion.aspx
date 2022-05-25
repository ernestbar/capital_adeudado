<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de ingresos NAFIBO - Totales por sector" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCaja", "reporteIngresosNafiboTotalesUrbanizacion") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
      
    
    Public Sub cargarReporte()
        Dim Codigo_moneda As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo
        Dim reporte As New rpt_ingresosNafiboTotalesUrbanizacion()
        reporte.Encabezado(ddl_sucursal.SelectedItem.Text, cp_desde.SelectedDate, cp_hasta.SelectedDate, Int32.Parse(ddl_cajero.SelectedValue), Int32.Parse(rbl_forma_pago.SelectedValue), rbl_moneda.SelectedItem.Text.ToUpper, rbl_consolidado.SelectedItem.Text.ToUpper, Codigo_moneda)
        reporte.DataSource = cajaReporte.ReporteIngresosNafiboTotalesUrbanizacion(Integer.Parse(ddl_sucursal.SelectedValue), Int32.Parse(rbl_forma_pago.SelectedValue), Int32.Parse(ddl_cajero.SelectedValue), cp_desde.SelectedDate, cp_hasta.SelectedDate, Integer.Parse(rbl_moneda.SelectedValue), rbl_consolidado.SelectedValue.Equals("True"))
        Reporte1.WebView.Report = reporte
    End Sub
        

    Protected Sub ddl_cajero_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_cajero.DataBound
        ddl_cajero.Items.Insert(0, New ListItem("Todos", "0"))
        ddl_cajero.SelectedValue = "0"
    End Sub
   
    Protected Sub btn_mostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        cargarReporte()
    End Sub
    
    Protected Sub ddl_sucursal_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_sucursal.DataBound
        ddl_sucursal.Items.Insert(0, New ListItem("Todos", "0"))
        Dim id_sucursal_predeterminada As Integer = sucursal.IdSucursalPorNum(Integer.Parse(ConfigurationManager.AppSettings("num_sucursal")))
        If ddl_sucursal.Items.FindByValue(id_sucursal_predeterminada) IsNot Nothing Then
            ddl_sucursal.SelectedValue = id_sucursal_predeterminada
        Else
            ddl_sucursal.SelectedIndex = 0
        End If
    End Sub

    Protected Sub rbl_moneda_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_moneda.DataBound
        If rbl_moneda.Items.Count > 0 Then
            rbl_moneda.SelectedIndex = 0
        End If
    End Sub
    Protected Sub rbl_consolidado_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_consolidado.DataBound
        If rbl_consolidado.Items.Count > 0 Then
            rbl_consolidado.SelectedIndex = 0
        End If
        lbl_consolidado_enun.Text = "Datos contemplados:"
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteCaja" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte de ingresos NAFIBO - Totales por sector</td>
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
                                <td class="formTdEnun">Sucursal:</td>
                                <td class="formTdDato">
                                    <asp:DropDownList ID="ddl_sucursal" runat="server" DataSourceID="ods_lista_sucursal" DataTextField="nombre" DataValueField="id_sucursal">
                                    </asp:DropDownList>
                                    <%--[id_sucursal],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_lista_sucursal" runat="server" TypeName="terrasur.sucursal" SelectMethod="ListaParaDDL">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
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
                                    <ew:CalendarPopup ID="cp_hasta" runat="server" AutoPostBack="false">
                                    </ew:CalendarPopup>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_forma_pago_enun" runat="server" Text="Forma de pago:"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_forma_pago" runat="server" AutoPostBack="false" RepeatDirection="Horizontal" CausesValidation="true"  ValidationGroup="forma_pago" CellPadding="0" CellSpacing="0">
                                        <asp:ListItem Value="0" Selected="True" >Todos</asp:ListItem>
                                        <asp:ListItem Value="1">Efectivo</asp:ListItem>
                                        <asp:ListItem Value="2">DPR</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                           <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_usuario_enun" runat="server" Text="Usuario:"></asp:Label></td>
                               <td class="formTdDato">
                                   <asp:DropDownList ID="ddl_cajero" runat="server" AutoPostBack="false" DataSourceID="ods_cajero_lista"
                                       DataTextField="nombre_completo" DataValueField="id_usuario">
                                   </asp:DropDownList>
                                   <%--[id_usuario],[nombre]--%>
                                   <asp:ObjectDataSource ID="ods_cajero_lista" runat="server" TypeName="terrasur.usuario"
                                       SelectMethod="ListaCajerosNoEliminados"></asp:ObjectDataSource>
                               </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Moneda:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_moneda" runat="server" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                    <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
                                    <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_consolidado_enun" runat="server"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_consolidado" runat="server" DataSourceID="ods_lista_consolidado" DataValueField="valor" DataTextField="texto" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                    <%--[valor],[texto]--%>
                                    <asp:ObjectDataSource ID="ods_lista_consolidado" runat="server" TypeName="terrasur.general" SelectMethod="ListaOpcionesConsolidado">
                                    </asp:ObjectDataSource>
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

