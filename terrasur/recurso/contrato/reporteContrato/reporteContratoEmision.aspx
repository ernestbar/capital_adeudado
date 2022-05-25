<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Emisión de documentos a clientes" %>

<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>

<%@ Register src="~/recurso/contrato/reporteContrato/userControl/contratoEmisionFiltro.ascx" tagname="contratoEmisionFiltro" tagprefix="uc3" %>

<script runat="server">
    'Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs)
    '    'If Request.QueryString("ic") IsNot Nothing AndAlso Session("id_contrato") IsNot Nothing Then
    '    '    Session.Remove("id_contrato")
    '    'End If

    '    'If Request.QueryString("ic") IsNot Nothing Then
    '    '    general.CambiarMasterPage(Me, False)
    '    'End If
    'End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "reporteContrato", "reporteContratoEmision") Then
                cef1.Reset(0, "")
                'Page.Visible = True
                
                'Dim id_contrato As Integer = 0
                'If Not Integer.TryParse(Request.QueryString("ic"), id_contrato) Then
                '    id_contrato = 0
                'End If
                'Dim tipo_documento As String = Request.QueryString("td")
                
                'cef1.Reset(id_contrato, tipo_documento)

                'If id_contrato > 0 Or tipo_documento <> "" Then
                '    CargarReporte()
                'End If
            Else
                'Page.Visible = False
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
            'If Page.MasterPageFile.Contains("simple.master") Then
            '    'Reporte1.Formato_Web = False
            'End If
        End If
    End Sub
    
    Protected Sub btn_mostrar_reporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tabla As Data.DataTable = terrasur.emDoc.emision.Lista(cef1.fecha_inicio, cef1.fecha_fin, cef1.tipo_documento_codigo, cef1.id_usuario, cef1.num_contrato, cef1.cliente, cef1.para_cliente)
        
        Dim rep As New rpt_contratoEmision
        rep.CargarEncabezado(Profile.nombre_persona, cef1.string_fecha, cef1.string_tipo_documento, cef1.num_contrato, cef1.string_usuario, cef1.cliente, cef1.string_tipo_emision, tabla.Rows.Count)
        rep.DataSource = tabla
        Reporte1.WebView.Report = rep
        
        'gv0.DataSource = terrasur.emDoc.emision.Lista(cef1.fecha_inicio, cef1.fecha_fin, cef1.codigo_tipo_documento, cef1.id_usuario, cef1.num_contrato, cef1.cliente, cef1.para_cliente)
        'gv0.DataBind()
    End Sub
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="emisionDocCliente" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <table class="priTable">
        <tr><td class="priTdTitle"><asp:Label ID="lbl_titulo" runat="server" Text="Emisión de documentos a clientes"></asp:Label></td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_filtro" runat="server" DefaultButton="btn_mostrar_reporte">
                    <table class="formEntTable">
                        <tr><td><uc3:contratoEmisionFiltro ID="cef1" runat="server" /></td></tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:ButtonAction ID="btn_mostrar_reporte" runat="server" Text="Mostrar reporte" TextoEnviando="Generando reporte" CausesValidation="true" onclick="btn_mostrar_reporte_Click"/>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <uc2:reporte ID="Reporte1" runat="server" />
                <%--<asp:GridView ID="gv0" runat="server"></asp:GridView>--%>
            </td>
        </tr>
    </table>
</asp:Content>