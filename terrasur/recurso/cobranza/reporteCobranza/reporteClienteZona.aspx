<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de clientes por zona" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteCobranza", "reporteClienteZona") Then
                ddl_sector.DataBind()
                ddl_zona.DataBind()
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
  
    Public Sub cargarReporte()
        Dim reporte As New rpt_clientes_zonas()
        Dim cobrador As Boolean
        Dim fechas As Integer = 0
        Dim fecha_inicio As DateTime
        Dim fecha_fin As DateTime
        If rbl_cobrador.SelectedValue = "1" Then
            cobrador = True
        Else
            cobrador = False
        End If
        If (cp_inicio.SelectedValue.HasValue = False And cp_fin.SelectedValue.HasValue = False) Then
            fechas = 0
            fecha_inicio = "01/10/1900"
            fecha_fin = "12/12/9999"
        End If
        If (cp_inicio.SelectedValue.HasValue = True And cp_fin.SelectedValue.HasValue = True) Then
            fechas = 1
            fecha_inicio = cp_inicio.SelectedDate
            fecha_fin = cp_fin.SelectedDate
        End If
        If (cp_inicio.SelectedValue.HasValue = True And cp_fin.SelectedValue.HasValue = False) Then
            fechas = 2
            fecha_inicio = cp_inicio.SelectedDate
            fecha_fin = "12/12/9999"
        End If
        If (cp_inicio.SelectedValue.HasValue = False And cp_fin.SelectedValue.HasValue = True) Then
            fechas = 3
            fecha_inicio = "10/10/1900"
            fecha_fin = cp_fin.SelectedDate
        End If
        reporte.DataSource = cobranzaReporte.ReporteClienteZona(Int32.Parse(ddl_sector.SelectedValue), Int32.Parse(ddl_zona.SelectedValue), cobrador, fecha_inicio, fecha_fin)
        Reporte1.WebView.Report = reporte
    End Sub
        

    Protected Sub ddl_sector_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_sector.DataBound
        ddl_sector.Items.Insert(0, New ListItem("Todos", "0"))
        ddl_sector.SelectedValue = "0"
    End Sub
    
    Protected Sub ddl_zona_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_zona.DataBound
        ddl_zona.Items.Insert(0, New ListItem("Todos", "0"))
        ddl_zona.SelectedValue = "0"
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
        <td class="priTdTitle">Reporte de clientes por zona</td>
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
                                    <asp:Label ID="lbl_sector_enun" runat="server" Text="Sector:"></asp:Label></td>
                               <td class="formTdDato">
                                   <asp:DropDownList ID="ddl_sector" runat="server" AutoPostBack="true" DataSourceID="ods_sector_lista"
                                       DataTextField="nombre" DataValueField="id_sector">
                                   </asp:DropDownList>
                                   <%--[id_localizacion],[nombre]--%>
                                   <asp:ObjectDataSource ID="ods_sector_lista" runat="server" TypeName="terrasur.sector_zona"
                                       SelectMethod="Lista"></asp:ObjectDataSource>
                               </td>
                            </tr>
                             <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_zona" runat="server" Text="Zona:"></asp:Label></td>
                               <td class="formTdDato">
                                   <asp:DropDownList ID="ddl_zona" runat="server" AutoPostBack="false" DataSourceID="ods_zona_lista"
                                       DataTextField="nombre" DataValueField="id_zona">
                                   </asp:DropDownList>
                                   <%--[id_localizacion],[nombre]--%>
                                   <asp:ObjectDataSource ID="ods_zona_lista" runat="server" TypeName="terrasur.zona"
                                       SelectMethod="Lista">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Id_sector" Type="Int32" ControlID="ddl_sector"
                                                            PropertyName="SelectedValue" /> 
                                        </SelectParameters>    
                                   </asp:ObjectDataSource>
                               </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">
                                    Fecha de cuota inicial:</td>
                                <td class="formTdDato">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <ew:CalendarPopup ID="cp_inicio"  Nullable="true" runat="server">
                                                </ew:CalendarPopup>
                                            </td>
                                            <td>
                                                -</td>
                                            <td>
                                                <ew:CalendarPopup ID="cp_fin" Nullable="true" runat="server">
                                                </ew:CalendarPopup>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                           <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_cobranza_enun" runat="server" Text="Cobranza:"></asp:Label></td>
                               <td class="formTdDato">
                                   <asp:RadioButtonList ID="rbl_cobrador" runat="server" RepeatDirection="Horizontal" AutoPostBack="false"> 
                                       <asp:ListItem Selected="True" Value="1">Por cobrador</asp:ListItem>
                                       <asp:ListItem Value="2">Sin cobrador</asp:ListItem>
                                   </asp:RadioButtonList></td>
                            </tr>
                            <tr>
                                <td class="formEntTdButton" colspan="2">
                                   <asp:Button ID="btn_mostrar" runat="server"  SkinID="btnAccion" Text="Mostrar reporte"/>
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

