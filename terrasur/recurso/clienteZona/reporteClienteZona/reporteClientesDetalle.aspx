<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Reporte de clientes en detalle" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc2" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/clienteZona/cliente/userControl/clienteCriterio.ascx" TagName="clienteCriterio" TagPrefix="uc3" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteClienteZona", "reporteClientesDetalle") Then
                ddl_zona.DataBind()
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Public Sub cargarReporte()
        Dim fecha As DateTime
        If (cp_fecha.SelectedValue.HasValue = False) Then
            fecha = "01/01/1900"
        Else
            fecha = cp_fecha.SelectedDate
        End If
        Dim reporte As New reporteClientesDetalle()
        reporte.DataSource = cliente.ReporteClientesDetalle(ClienteCriterio1.ci, ClienteCriterio1.paterno, ClienteCriterio1.materno, ClienteCriterio1.nombres, ClienteCriterio1.num_contrato, Integer.Parse(ddl_estado.SelectedValue), fecha, Integer.Parse(rbl_preferencial.SelectedValue), Integer.Parse(ddl_zona.SelectedValue), Integer.Parse(rbl_transitorio.SelectedValue))
        Reporte1.WebView.Report = reporte
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
    <uc2:recursoMaster ID="RecursoMaster1" runat="server" recurso="reporteClienteZona" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
     <asp:ScriptManager runat="server">
    </asp:ScriptManager>
<table class="priTable">
    <tr>
        <td class="priTdTitle">Reporte de clientes en detalle</td>
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
                                <td class="tdBusqueda" colspan="2">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="tdMsg">
                                                <asp:Msg ID="msg_criterio" runat="server">
                                                </asp:Msg></td>
                                        </tr>
                                        <tr>
                                            <td class="formHorEntTdForm">
                                                <uc3:clienteCriterio ID="ClienteCriterio1" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">
                                    Estado del contrato:</td>
                                <td class="formTdDato" colspan="4">
                                    <asp:DropDownList ID="ddl_estado" runat="server">
                                        <asp:ListItem Text="Todos" Value="-2" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Preasignado" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Vigente" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Revertido" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Liquidado" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTdEnun">
                                    Fecha última modificación:</td>
                                <td class="formTdDato">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <ew:CalendarPopup ID="cp_fecha"  Nullable="true" runat="server">
                                                </ew:CalendarPopup>
                                            </td>
                                        </tr>
                                    </table>
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
                                            <asp:Parameter Name="Id_sector" Type="Int32" DefaultValue="0" /> 
                                        </SelectParameters>    
                                   </asp:ObjectDataSource>
                               </td>
                            </tr>
                           <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_preferencial_enun" runat="server" Text="Tipo de cliente:"></asp:Label></td>
                               <td class="formTdDato">
                                   <asp:RadioButtonList ID="rbl_preferencial" runat="server" RepeatDirection="Horizontal" AutoPostBack="false"> 
                                       <asp:ListItem Selected="True" Value="2">Todos</asp:ListItem>
                                       <asp:ListItem Value="0">Normales</asp:ListItem>
                                       <asp:ListItem Value="1">Preferenciales</asp:ListItem>
                                   </asp:RadioButtonList></td>
                            </tr>
                              <tr>
                                <td class="formTdEnun">
                                    <asp:Label ID="lbl_transitorio_enun" runat="server" Text="Cliente:"></asp:Label></td>
                               <td class="formTdDato">
                                   <asp:RadioButtonList ID="rbl_transitorio" runat="server" RepeatDirection="Horizontal" AutoPostBack="false"> 
                                       <asp:ListItem Selected="True" Value="2">Todos</asp:ListItem>
                                       <asp:ListItem Value="0">Permanentes</asp:ListItem>
                                       <asp:ListItem Value="1">Transitorios</asp:ListItem>
                                   </asp:RadioButtonList></td>
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

