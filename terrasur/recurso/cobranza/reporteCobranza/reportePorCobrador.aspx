<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Pagos depositados por cobrador" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCobranza", "reportePorCobrador") Then
                ddl_cobrador.DataBind()
                
                rbl_disgragar.SelectedValue = "False"
                lbl_disgregar.Visible = ",adm,finanzas,gerencia,consultas,".Contains(Profile.entorno.codigo_modulo)
                rbl_disgragar.Visible = ",adm,finanzas,gerencia,consultas,".Contains(Profile.entorno.codigo_modulo)
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
      
    
    Public Sub cargarReporte()
        If rbl_negocio.SelectedValue = "False" Then
            If Boolean.Parse(rbl_disgragar.SelectedValue) = False Then
                Dim reporte As New rpt_por_cobrador()
                reporte.Encabezado(cp_desde.SelectedDate, cp_hasta.SelectedDate, Int32.Parse(ddl_cobrador.SelectedValue))
                Dim dv As Data.DataView = cobranzaReporte.ReportePorCobrador(cp_desde.SelectedDate, cp_hasta.SelectedDate, Int32.Parse(ddl_cobrador.SelectedValue)).DefaultView
                dv.Sort = "id_usuario,num_control,numero_contrato"
                reporte.DataSource = dv
                Reporte1.WebView.Report = reporte
            Else
                Dim reporte As New rpt_por_cobrador2()
                reporte.Encabezado(cp_desde.SelectedDate, cp_hasta.SelectedDate, Int32.Parse(ddl_cobrador.SelectedValue))
                Dim dv As Data.DataView = cobranzaReporte.ReportePorCobrador(cp_desde.SelectedDate, cp_hasta.SelectedDate, Int32.Parse(ddl_cobrador.SelectedValue)).DefaultView
                dv.Sort = "id_usuario,num_control,numero_contrato"
                reporte.DataSource = dv
                Reporte1.WebView.Report = reporte
            End If
        Else
            If Boolean.Parse(rbl_disgragar.SelectedValue) = False Then
                Dim reporte As New rpt_por_cobrador_negocio()
                reporte.Encabezado(cp_desde.SelectedDate, cp_hasta.SelectedDate, Int32.Parse(ddl_cobrador.SelectedValue))
                reporte.DataSource = cobranzaReporte.ReportePorCobrador(cp_desde.SelectedDate, cp_hasta.SelectedDate, Int32.Parse(ddl_cobrador.SelectedValue)).DefaultView
                Reporte1.WebView.Report = reporte
            Else
                Dim reporte As New rpt_por_cobrador_negocio2()
                reporte.Encabezado(cp_desde.SelectedDate, cp_hasta.SelectedDate, Int32.Parse(ddl_cobrador.SelectedValue))
                reporte.DataSource = cobranzaReporte.ReportePorCobrador(cp_desde.SelectedDate, cp_hasta.SelectedDate, Int32.Parse(ddl_cobrador.SelectedValue)).DefaultView
                Reporte1.WebView.Report = reporte
            End If
        End If
    End Sub
        

    Protected Sub ddl_cobrador_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_cobrador.DataBound
        ddl_cobrador.Items.Insert(0, New ListItem("Todos", "0"))
        ddl_cobrador.SelectedValue = "0"
    End Sub

   
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
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
        <td class="priTdTitle">Pagos depositados por cobrador</td>
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
                                    <ew:CalendarPopup ID="cp_desde" runat="server" AutoPostBack="false" >
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
                                   <asp:DropDownList ID="ddl_cobrador" runat="server" AutoPostBack="false" DataSourceID="ods_cobrador_lista" DataTextField="nombre_completo" DataValueField="id_usuario" >
                                   </asp:DropDownList>
                                   <%--[id_localizacion],[nombre]--%>
                                   <asp:ObjectDataSource ID="ods_cobrador_lista" runat="server" TypeName="terrasur.cobrador" SelectMethod="ListaNoEliminado">
                                   </asp:ObjectDataSource>
                               </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">Agrupación:</td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_negocio" runat="server" CellPadding="0" CellSpacing="0">
                                        <asp:ListItem Text="Agrupar por cobrador" Value="False" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Agrupar por negocio (de la dosificación)" Value="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun"><asp:Label ID="lbl_disgregar" runat="server" Text="Mostrar columnas:"></asp:Label></td>
                                <td class="formTdDato">
                                    <asp:RadioButtonList ID="rbl_disgragar" runat="server" CellPadding="0" CellSpacing="0">
                                        <asp:ListItem Text="No mostrar columnas de pago con Nº de cuota y sin Nº de cuota" Value="False" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Mostrar columnas de pago con Nº de cuota y sin Nº de cuota" Value="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton" colspan="2">
                                   <asp:Button ID="btn_mostrar_reporte" runat="server" SkinID="btnAccion" Text="Mostrar reporte"/>
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

