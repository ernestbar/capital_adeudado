<%@ Page Language="VB" MasterPageFile="~/modulo/simple.master" Title="Historial de bloqueo de contratos" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register src="~/recurso/sintesis/sBloqueado/userControl/sBloqueadoCriterioBusqueda.ascx" tagname="sBloqueadoCriterioBusqueda" tagprefix="uc2" %>
<script runat="server">
    Protected Property primer_acceso() As Boolean
        Get
            Return Boolean.Parse(lbl_primer_acceso.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_primer_acceso.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "sBloqueado", "historial") Then
                primer_acceso = True
            Else
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mostrar_reporte.Click
        primer_acceso = False
        gv_bloqueados.DataBind()
    End Sub

    
    Protected Sub ods_lista_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs)
        If primer_acceso = True Then
            e.InputParameters("Fecha_inicio") = DateTime.Parse("01/01/2900")
        Else
            e.InputParameters("Fecha_inicio") = sBloqueadoCriterioBusqueda1.fecha_inicio
        End If
        e.InputParameters("Fecha_fin") = sBloqueadoCriterioBusqueda1.fecha_fin
        e.InputParameters("Num_contrato") = sBloqueadoCriterioBusqueda1.num_contrato
        e.InputParameters("Usuario") = sBloqueadoCriterioBusqueda1.usuario
        e.InputParameters("Activo") = sBloqueadoCriterioBusqueda1.activo
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="sBloqueado" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:Label ID="lbl_primer_acceso" runat="server" Text="true" Visible="false"></asp:Label>

    <table class="priTable">
        <tr><td class="priTdTitle"><asp:Label ID="lbl_titulo" runat="server" Text="Historial de bloqueo de contratos"></asp:Label></td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_filtro" runat="server" DefaultButton="btn_mostrar_reporte">
                    <table class="formEntTable">
                        <tr>
                            <td>
                                <uc2:sBloqueadoCriterioBusqueda ID="sBloqueadoCriterioBusqueda1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:ButtonAction ID="btn_mostrar_reporte" runat="server" Text="Mostrar datos" TextoEnviando="Generando reporte"/>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gv_bloqueados" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista" DataKeyNames="id_bloqueado">
                    <Columns>
                        <asp:BoundField HeaderText="Nº contrato" DataField="num_contrato" ItemStyle-CssClass="gvCell1" />
                        <asp:BoundField HeaderText="Estado" DataField="estado" />

                        <asp:BoundField HeaderText="Bloqueo" DataField="estado_bloqueo" />
                        
                        <asp:BoundField HeaderText="Fecha (bloq.)" DataField="activo_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                        <asp:BoundField HeaderText="Usuario (bloq.)" DataField="activo_usuario" />
                        <asp:BoundField HeaderText="Observación (bloq.)" DataField="activo_observacion" />

                        <asp:BoundField HeaderText="Fecha (desbl.)" DataField="inactivo_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                        <asp:BoundField HeaderText="Usuario (desbl.)" DataField="inactivo_usuario" />
                        <asp:BoundField HeaderText="Observación (desbl.)" DataField="inactivo_observacion" />
                    </Columns>
                </asp:GridView>
                <%--[id_bloqueado],[num_contrato],[estado],[estado_bloqueo],
                [activo_fecha],[activo_usuario],[activo_observacion],
                [inactivo_fecha],[inactivo_usuario],[inactivo_observacion]--%>
                <asp:ObjectDataSource ID="ods_lista" runat="server" TypeName="terrasur.sintesis.s_bloqueado" SelectMethod="Lista" OnSelecting="ods_lista_Selecting">
                    <SelectParameters>
                        <asp:Parameter Name="Fecha_inicio" Type="DateTime" />
                        <asp:Parameter Name="Fecha_fin" Type="DateTime" />
                        <asp:Parameter Name="Num_contrato" Type="String" />
                        <asp:Parameter Name="Usuario" Type="String" />
                        <asp:Parameter Name="Activo" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>